using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public class TaxRuleEntry : BaseEntity
    {
        public TaxRulesEntity TaxRulesEntity { get; set; }
        public List<TaxRuleDetailsEntity> TaxRuleDetailsEntities { get; set; }

        public TaxRuleEntry()
        {
            TaxRuleDetailsEntities = new List<TaxRuleDetailsEntity>();
            TaxRulesEntity = new TaxRulesEntity();
        }

        public static implicit operator TaxRuleEntry(TaxRuleModel tax)
        {
            return new TaxRuleEntry()
            {
               
                Id = tax.Id,
                IsActive = tax.IsActive,
                TaxRuleDetailsEntities = tax.TaxRuleDetails.Select(x => (TaxRuleDetailsEntity)x).ToList()
            };
        }

        public static implicit operator TaxRuleModel(TaxRuleEntry tax)
        {
            return new TaxRuleModel()
            {

                Id = tax.Id,
                IsActive = tax.IsActive,
                TaxRule=(TaxRule)tax.TaxRulesEntity,
                TaxRuleDetails = tax.TaxRuleDetailsEntities.Select(x => (TaxRuleDetail)x).ToList()
            };
        }

    }
    public class TaxRuleEntryRepository : BaseRepository<TaxRuleEntry>
    {
        private readonly IRepository<TaxRulesEntity> _TaxRuleRepository;
        private readonly IRepository<TaxRuleDetailsEntity> _TaxRuleDetailRepository;

        public TaxRuleEntryRepository(IRepository<TaxRulesEntity> TaxRuleRepository, IRepository<TaxRuleDetailsEntity> TaxRuleDetailRepository, SavuDiaryDBContext context) : base(context)
        {
            _TaxRuleRepository = TaxRuleRepository;
            _TaxRuleDetailRepository = TaxRuleDetailRepository;
        }

        public override async Task<TaxRuleEntry> Delete(TaxRuleEntry entity)
        {
            entity.TaxRulesEntity = await _TaxRuleRepository.Delete(entity.TaxRulesEntity);
            if (entity.TaxRuleDetailsEntities != null)
            {
                foreach (var item in entity.TaxRuleDetailsEntities)
                {
                    await _TaxRuleDetailRepository.Delete(item);
                }
            }
            return entity;
        }

        public override IQueryable<TaxRuleEntry> GetAll()
        {
            var list = _TaxRuleRepository.GetAll();
            return list.ToList().Select(x => new TaxRuleEntry() { TaxRulesEntity = x, Id = x.Id }).AsQueryable();
        }

        public override async Task<TaxRuleEntry> GetById(Guid id)
        {
            var entry = await _TaxRuleRepository.GetById(id);
            var details = _TaxRuleDetailRepository.GetAll().Where(x => x.TaxRuleId == id).ToList();
            return new TaxRuleEntry()
            {
                TaxRulesEntity = entry,
                Id = id,
                TaxRuleDetailsEntities=details,
            };
        }

        public override async Task<TaxRuleEntry> Insert(TaxRuleEntry entity)
        {
            entity.TaxRulesEntity = await _TaxRuleRepository.Insert(entity.TaxRulesEntity);
            if (entity.TaxRuleDetailsEntities != null)
            {
                foreach (var item in entity.TaxRuleDetailsEntities)
                {
                    await _TaxRuleDetailRepository.Insert(item);
                }
            }
            return entity;
        }

        public override async Task<TaxRuleEntry> Update(TaxRuleEntry entity)
        {
            entity.TaxRulesEntity = await _TaxRuleRepository.Update(entity.TaxRulesEntity);
            if (entity.TaxRuleDetailsEntities != null)
            {
                foreach (var item in entity.TaxRuleDetailsEntities)
                {
                    if (item.Id != Guid.Empty && item.IsActive == true)
                    {
                        await _TaxRuleDetailRepository.Update(item);
                    }
                    else if (item.Id != Guid.Empty && item.IsActive == false)
                    {
                        await _TaxRuleDetailRepository.Delete(item);
                    }
                    else if (item.Id == Guid.Empty && item.IsActive == true)
                    {
                        await _TaxRuleDetailRepository.Insert(item);
                    }
                }
            }
            return entity;
        }
    }
}
