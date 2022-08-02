using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class PurchaseEntry : BaseEntity
    {
        public PurchaseEntity PurchaseEntity { get; set; }
        public List<PurchaseDetailEntity> PurchaseDetailList { get; set; }

        public PurchaseEntry()
        {
            PurchaseDetailList = new List<PurchaseDetailEntity>();
            PurchaseEntity = new PurchaseEntity();
        }

        public static implicit operator PurchaseEntry(Purchase purchase)
        {
            return new PurchaseEntry()
            {
                PurchaseEntity = new PurchaseEntity()
                {
                    Amount = purchase.Amount,
                    SupplierId = purchase.SupplierId,
                    SupplierName = purchase.SupplierName,
                    DateTime = purchase.DateTime,
                    DiscountAmount = purchase.DiscountAmount,
                    Id = purchase.Id,
                    IsActive = purchase.IsActive,
                    NetAmount = purchase.NetAmount,
                    Notes = purchase.Notes,
                    PurchaseNo = purchase.PurchaseNo,


                },
                Id = purchase.Id,
                IsActive = purchase.IsActive,
                PurchaseDetailList = purchase.PurchaseDetails.Select(x => (PurchaseDetailEntity)x).ToList()
            };
        }

        public static implicit operator Purchase(PurchaseEntry purchase)
        {
            try
            {
                var purchase1 = new Purchase()
                {

                    PurchaseNo = purchase.PurchaseEntity.PurchaseNo,
                    Notes = purchase.PurchaseEntity.Notes,
                    NetAmount = purchase.PurchaseEntity.NetAmount,
                    IsActive = purchase.IsActive,
                    Id = purchase.PurchaseEntity.Id,
                    Amount = purchase.PurchaseEntity.Amount,
                    SupplierId = purchase.PurchaseEntity.SupplierId,
                    SupplierName = purchase.PurchaseEntity.SupplierName,
                    DateTime = purchase.PurchaseEntity.DateTime,
                    DiscountAmount = purchase.PurchaseEntity.DiscountAmount,

                };
                purchase1.PurchaseDetails = purchase.PurchaseDetailList.Select(x => (PurchaseDetail)x).ToList();
                return purchase1;
            }
            catch
            {
                throw;
            }
        }
    }
    public class PurchaseEntryRepository : BaseRepository<PurchaseEntry>
    {
        private readonly IRepository<PurchaseEntity> _purchaseRepository;
        private readonly IRepository<PurchaseDetailEntity> _purchaseDetailRepository;
        private readonly IRepository<TaxRecordDetailEntity> _taxRecordDetailsRepository;
        private readonly IRepository<StockMangementEntity> _stockManagementRepository;

        public PurchaseEntryRepository(IRepository<PurchaseEntity> purchaseRepository
            , IRepository<PurchaseDetailEntity> purchaseDetailRepository
            , IRepository<TaxRecordDetailEntity> taxRecordDetailsRepository
            , IRepository<StockMangementEntity> stockManagementRepository
            , SavuDiaryDBContext context) : base(context)
        {
            _purchaseRepository = purchaseRepository;
            _purchaseDetailRepository = purchaseDetailRepository;
            _taxRecordDetailsRepository = taxRecordDetailsRepository;
            _stockManagementRepository = stockManagementRepository;
        }

        public override async Task<PurchaseEntry> Delete(PurchaseEntry entity)
        {
            entity.PurchaseEntity = await _purchaseRepository.Delete(entity.PurchaseEntity);
            if (entity.PurchaseDetailList != null)
            {

                foreach (var item in entity.PurchaseDetailList)
                {
                    item.PurchaseId = entity.PurchaseEntity.Id;
                    await _purchaseDetailRepository.Delete(item);
                    await UpdateAndSaveTaxDetails(item, entity.PurchaseEntity.PurchaseNo);
                }
            }
            return entity;
        }

        public override IQueryable<PurchaseEntry> GetAll()
        {
            var list = _purchaseRepository.GetAll();
            return list.ToList().Select(x => new PurchaseEntry() { PurchaseEntity = x, Id = x.Id }).AsQueryable();
        }

        public override async Task<PurchaseEntry> GetById(Guid id)
        {
            var entry = await _purchaseRepository.GetById(id);
            var details = _purchaseDetailRepository.GetAll()
                .Where(x => x.PurchaseId == id)
                .ToList();
            foreach (var item in details)
            {
                var result = _taxRecordDetailsRepository.Get(x => x.RecordId == id);
                item.TaxRecordDetailEntity = result.ToList();
            }
            var data = new PurchaseEntry()
            {
                PurchaseEntity = entry,
                Id = id,
                PurchaseDetailList = details,
            };
            return data;
        }

        public override async Task<PurchaseEntry> Insert(PurchaseEntry entity)
        {
            entity.PurchaseEntity = await _purchaseRepository.Insert(entity.PurchaseEntity);
            if (entity.PurchaseDetailList != null)
            {
                foreach (var item in entity.PurchaseDetailList)
                {

                    item.PurchaseId = entity.PurchaseEntity.Id;
                    await _purchaseDetailRepository.Insert(item);
                    await UpdateAndSaveTaxDetails(item, entity.PurchaseEntity.PurchaseNo);
                }
            }
            return entity;
        }

        public override async Task<PurchaseEntry> Update(PurchaseEntry entity)
        {
            entity.PurchaseEntity = await _purchaseRepository.Update(entity.PurchaseEntity);
            if (entity.PurchaseDetailList != null)
            {
                foreach (var item in entity.PurchaseDetailList)
                {
                    item.PurchaseId = entity.PurchaseEntity.Id;
                    if (item.Id != Guid.Empty && item.IsActive == true)
                    {

                        await _purchaseDetailRepository.Update(item);
                    }
                    else if (item.Id != Guid.Empty && item.IsActive == false)
                    {

                        await _purchaseDetailRepository.Delete(item);
                    }
                    else if (item.Id == Guid.Empty && item.IsActive == true)
                    {
                        await _purchaseDetailRepository.Insert(item);
                    }
                    await UpdateAndSaveTaxDetails(item, entity.PurchaseEntity.PurchaseNo);
                }
            }
            return entity;
        }

        protected async Task UpdateAndSaveTaxDetails(PurchaseDetail detail, long no)
        {
            foreach (var tax in detail.TaxRecordDetails)
            {
                tax.ProductId = detail.ProductId;
                tax.RecordDetailId = detail.Id;
                tax.RecordId = detail.PurchaseId;
                tax.RecordNo = no;
                if (tax.Id == Guid.Empty && tax.IsActive)
                {
                    var taxd = await _taxRecordDetailsRepository.Insert(tax);
                    tax.Id = taxd.Id;
                    var stocks = new StockMangementEntity()
                    {
                        Date = DateTime.Now,
                        InQuantity = 0,
                        IsActive = detail.IsActive,
                        OutQuantity = detail.Quantity,
                        Price = detail.Price,
                        ProductId = detail.ProductId,
                        Rate = detail.Price,
                        RecordDetailId = detail.Id,
                        RecordId = detail.PurchaseId,
                        UniqueIdentifier = Guid.NewGuid().ToString(),

                    };
                    await _stockManagementRepository.Insert(stocks);
                }
                else if (tax.Id != Guid.Empty && tax.IsActive)
                {
                    var taxd = await _taxRecordDetailsRepository.Update(tax);
                    tax.Id = taxd.Id;
                    var stocks = _stockManagementRepository.Get(x => x.RecordDetailId == detail.Id).FirstOrDefault();
                    if (stocks != null)
                    {

                        stocks.Date = DateTime.Now;
                        stocks.InQuantity = 0;
                        stocks.IsActive = detail.IsActive;
                        stocks.OutQuantity = detail.Quantity;
                        stocks.Price = detail.Price;
                        stocks.ProductId = detail.ProductId;
                        stocks.Rate = detail.Price;
                        stocks.RecordDetailId = detail.Id;
                        stocks.RecordId = detail.PurchaseId;
                        stocks.UniqueIdentifier = Guid.NewGuid().ToString();
                        await _stockManagementRepository.Update(stocks);
                    }
                }
                else if (tax.Id != Guid.Empty && tax.IsActive == false)
                {
                    var taxd = await _taxRecordDetailsRepository.Delete(tax);
                    tax.Id = taxd.Id;
                    var stocks = _stockManagementRepository.Get(x => x.RecordDetailId == detail.Id).FirstOrDefault();
                    if (stocks != null)
                    {
                        await _stockManagementRepository.Delete(stocks);
                    }
                }
                
            }
        }
    }
}
