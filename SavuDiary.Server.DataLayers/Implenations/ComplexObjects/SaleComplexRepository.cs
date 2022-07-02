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
    public class SaleEntryRepository : IRepository<SaleEntry>
    {
        private readonly IRepository<SaleEntity> _saleRepository;
        private readonly IRepository<SaleDetailEntity> _saleDetailRepository;

        public SaleEntryRepository(IRepository<SaleEntity> saleRepository, IRepository<SaleDetailEntity> saleDetailRepository)
        {
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
        }

        public async Task<SaleEntry> Delete(SaleEntry entity)
        {
            entity.SaleEntity = await _saleRepository.Delete(entity.SaleEntity);
            if (entity.SaleDetailList != null)
            {
                foreach (var item in entity.SaleDetailList)
                {
                    await _saleDetailRepository.Delete(item);
                }
            }
            return entity;
        }

        public IQueryable<SaleEntry> GetAll()
        {
            var list = _saleRepository.GetAll();
            return list.ToList().Select(x => new SaleEntry() { SaleEntity = x, Id = x.Id }).AsQueryable();
        }

        public async Task<SaleEntry> GetById(Guid id)
        {
            var entry = await _saleRepository.GetById(id);
            return new SaleEntry()
            {
                SaleEntity = entry,
                Id = id,
            };
        }

        public async Task<SaleEntry> Insert(SaleEntry entity)
        {
            entity.SaleEntity = await _saleRepository.Insert(entity.SaleEntity);
            if (entity.SaleDetailList != null)
            {
                foreach (var item in entity.SaleDetailList)
                {
                    await _saleDetailRepository.Insert(item);
                }
            }
            return entity;
        }

        public async Task<SaleEntry> Update(SaleEntry entity)
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
                }
            }
            return entity;
        }
    }
}
