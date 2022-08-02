using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class SaleEntry : BaseEntity
    {
        public SaleEntity SaleEntity { get; set; }
        public List<SaleDetailEntity> SaleDetailList { get; set; }

        public SaleEntry()
        {
            SaleDetailList = new List<SaleDetailEntity>();
            SaleEntity = new SaleEntity();
        }

        public static implicit operator SaleEntry(Sale sale)
        {
            return new SaleEntry()
            {
                SaleEntity = (SaleEntity)sale,
                Id = sale.Id,
                IsActive = sale.IsActive,
                SaleDetailList = sale.SaleDetailsList.Select(x => (SaleDetailEntity)x).ToList()
            };
        }

        public static implicit operator Sale(SaleEntry sale)
        {
            var sale1 = (Sale)sale;
            sale1.SaleDetailsList=sale.SaleDetailList.Select(x=>(SaleDetail)x).ToList();
            return sale1;
        }
    }
    public class SaleEntryRepository : BaseRepository<SaleEntry>
    {
        private readonly IRepository<SaleEntity> _saleRepository;
        private readonly IRepository<SaleDetailEntity> _saleDetailRepository;
        private readonly IRepository<TaxRecordDetailEntity> _taxRecordDetailsRepository;
        private readonly IRepository<StockMangementEntity> _stockManagementRepository;

        public SaleEntryRepository(IRepository<SaleEntity> saleRepository, IRepository<SaleDetailEntity> saleDetailRepository, SavuDiaryDBContext context, IRepository<StockMangementEntity> stockManagementRepository, IRepository<TaxRecordDetailEntity> taxRecordDetailsRepository) : base(context)
        {
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
            _stockManagementRepository = stockManagementRepository;
            _taxRecordDetailsRepository = taxRecordDetailsRepository;
        }

        public override async Task<SaleEntry> Delete(SaleEntry entity)
        {
            entity.SaleEntity = await _saleRepository.Delete(entity.SaleEntity);
            if (entity.SaleDetailList != null)
            {
                foreach (var item in entity.SaleDetailList)
                {
                    await _saleDetailRepository.Delete(item);
                    await UpdateAndSaveTaxDetails(item, entity.SaleEntity.SaleNo);
                }
            }
            return entity;
        }

        public override IQueryable<SaleEntry> GetAll()
        {
            var list = _saleRepository.GetAll();
            return list.ToList().Select(x => new SaleEntry() { SaleEntity = x, Id = x.Id }).AsQueryable();
        }

        public override async Task<SaleEntry> GetById(Guid id)
        {
            var entry = await _saleRepository.GetById(id);
            return new SaleEntry()
            {
                SaleEntity = entry,
                Id = id,
            };
        }

        public override async Task<SaleEntry> Insert(SaleEntry entity)
        {
            entity.SaleEntity = await _saleRepository.Insert(entity.SaleEntity);
            if (entity.SaleDetailList != null)
            {
                foreach (var item in entity.SaleDetailList)
                {
                    await _saleDetailRepository.Insert(item);
                    await UpdateAndSaveTaxDetails(item, entity.SaleEntity.SaleNo);
                }
            }
            return entity;
        }

        public override async Task<SaleEntry> Update(SaleEntry entity)
        {
            entity.SaleEntity = await _saleRepository.Update(entity.SaleEntity);
            if (entity.SaleDetailList != null)
            {
                foreach (var item in entity.SaleDetailList)
                {
                    if (item.Id != Guid.Empty && item.IsActive == true)
                    {
                        await _saleDetailRepository.Update(item);
                    }
                    else if (item.Id != Guid.Empty && item.IsActive == false)
                    {
                        await _saleDetailRepository.Delete(item);
                    }
                    else if (item.Id == Guid.Empty && item.IsActive == true)
                    {
                        await _saleDetailRepository.Insert(item);
                    }
                    await UpdateAndSaveTaxDetails(item, entity.SaleEntity.SaleNo);
                }
            }
            return entity;
        }
        protected async Task UpdateAndSaveTaxDetails(SaleDetail detail, long no)
        {
            foreach (var tax in detail.TaxRecordDetails)
            {
                tax.ProductId = detail.ProductId;
                tax.RecordDetailId = detail.Id;
                tax.RecordId = detail.SaleId;
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
                        RecordId = detail.SaleId,
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
                        stocks.RecordId = detail.SaleId;
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
