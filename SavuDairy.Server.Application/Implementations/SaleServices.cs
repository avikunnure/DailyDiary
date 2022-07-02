using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class SaleServices : ISaleServices
    {
        private readonly IRepository<SaleEntity> _Repository;
        private readonly IRepository<SaleEntry> _EntryRepository;

        public SaleServices(IRepository<SaleEntity> repository, IRepository<SaleEntry> entryRepository)
        {
            _Repository = repository;
            _EntryRepository = entryRepository;
        }

        public Task<DataResponses<IEnumerable<Sale>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (Sale)x).AsEnumerable();
                return Task.FromResult( new DataResponses<IEnumerable<Sale>>(res,true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<Sale>>(false));
            }
        }


        public async Task<DataResponses<Sale>> Get(Guid id)

        {
            try
            {
               
                var res = await _EntryRepository.GetById(id);
                return new DataResponses<Sale>((Sale)res,true);
            }
            catch
            {
                return new DataResponses<Sale>( false); ;
            }
        }

        public async Task<DataResponses<Sale>> Post(Sale t)
        {
            try
            {
                var result = await _EntryRepository.Insert(t);

                return new DataResponses<Sale>((Sale)result, true);

            }
            catch
            {
                return new DataResponses<Sale>(t, false);
            }
        }

        public async Task<DataResponses<Sale>> Put(Sale t)
        {
            try
            {
                var result = await _EntryRepository.Update(t);

                return new DataResponses<Sale>((Sale)result, true);
            }
            catch
            {
                return new DataResponses<Sale>(t, false);
            }
        }

        public async Task<DataResponses<Sale>> Delete(Sale t)
        {
            try
            {
                var result = await _EntryRepository.Delete(t);

                return new DataResponses<Sale>((Sale)result, true);
            }
            catch
            {
                return new DataResponses<Sale>(t, false);
            }
        }
    }
}
