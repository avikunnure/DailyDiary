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
    public class PurchaseEntryRepository : IRepository<PurchaseEntry>
    {
        private readonly IRepository<PurchaseEntity> _purchaseRepository;
        private readonly IRepository<PurchaseDetailEntity> _purchaseDetailRepository;

        public PurchaseEntryRepository(IRepository<PurchaseEntity> purchaseRepository, IRepository<PurchaseDetailEntity> purchaseDetailRepository)
        {
            _purchaseRepository = purchaseRepository;
            _purchaseDetailRepository = purchaseDetailRepository;
        }

        public async Task<PurchaseEntry> Delete(PurchaseEntry entity)
        {
            entity.PurchaseEntity = await _purchaseRepository.Delete(entity.PurchaseEntity);
            if (entity.PurchaseDetailList != null)
            {

                foreach (var item in entity.PurchaseDetailList)
                {
                    item.PurchaseId = entity.PurchaseEntity.Id;
                    await _purchaseDetailRepository.Delete(item);
                }
            }
            return entity;
        }

        public IQueryable<PurchaseEntry> GetAll()
        {
            var list = _purchaseRepository.GetAll();
            return list.ToList().Select(x => new PurchaseEntry() { PurchaseEntity = x, Id = x.Id }).AsQueryable();
        }

        public async Task<PurchaseEntry> GetById(Guid id)
        {
            var entry = await _purchaseRepository.GetById(id);
            var details = _purchaseDetailRepository.GetAll()
                .Where(x => x.PurchaseId == id)
                .ToList();
            var  data= new PurchaseEntry()
            {
                PurchaseEntity = entry,
                Id = id,
                PurchaseDetailList = details,
            };
            return data;
        }

        public async Task<PurchaseEntry> Insert(PurchaseEntry entity)
        {
            entity.PurchaseEntity = await _purchaseRepository.Insert(entity.PurchaseEntity);
            if (entity.PurchaseDetailList != null)
            {
                foreach (var item in entity.PurchaseDetailList)
                {
                    item.PurchaseId = entity.PurchaseEntity.Id;
                    await _purchaseDetailRepository.Insert(item);
                }
            }
            return entity;
        }

        public async Task<PurchaseEntry> Update(PurchaseEntry entity)
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
                }
            }
            return entity;
        }
    }
}
