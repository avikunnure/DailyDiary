using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class TaxRuleServices : ITaxRuleServices
    {
        private readonly IRepository<TaxRulesEntity> _Repository;
        private readonly IRepository<TaxRuleEntry> _EntryRepository;

        public TaxRuleServices(IRepository<TaxRulesEntity> repository, IRepository<TaxRuleEntry> entryRepository)
        {
            _Repository = repository;
            _EntryRepository = entryRepository;
        }

        public Task<DataResponses<IEnumerable<TaxRuleModel>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x =>new TaxRuleModel() { TaxRule=(TaxRule)x,Id=x.Id,IsActive=x.IsActive}).AsEnumerable();
                return Task.FromResult( new DataResponses<IEnumerable<TaxRuleModel>>(res,true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<TaxRuleModel>>(false));
            }
        }


        public async Task<DataResponses<TaxRuleModel>> Get(Guid id)

        {
            try
            {
               
                var res = await _EntryRepository.GetById(id);
                return new DataResponses<TaxRuleModel>((TaxRuleModel)res,true);
            }
            catch
            {
                return new DataResponses<TaxRuleModel>( false); ;
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Post(TaxRuleModel t)
        {
            try
            {
                var result = await _EntryRepository.Insert(t);

                return new DataResponses<TaxRuleModel>((TaxRuleModel)result, true);

            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Put(TaxRuleModel t)
        {
            try
            {
                var result = await _EntryRepository.Update(t);

                return new DataResponses<TaxRuleModel>((TaxRuleModel)result, true);
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Delete(TaxRuleModel t)
        {
            try
            {
                var result = await _EntryRepository.Delete(t);

                return new DataResponses<TaxRuleModel>((TaxRuleModel)result, true);
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }
    }
}
