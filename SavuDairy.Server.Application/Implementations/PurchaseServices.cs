using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly IRepository<PurchaseEntity> _Repository;
        private readonly IRepository<PurchaseEntry> _EntryRepository;
        public PurchaseServices(IRepository<PurchaseEntity> customerRepository, IRepository<PurchaseEntry> entryRepository)
        {
            _Repository = customerRepository;
            _EntryRepository = entryRepository;
        }

        public Task<DataResponses<IEnumerable<Purchase>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (Purchase)x).AsEnumerable();
                return Task.FromResult(new DataResponses<IEnumerable<Purchase>>(res,true));
            }
            catch
            {
                return Task.FromResult(new DataResponses<IEnumerable<Purchase>>());
            }
        }


        public async Task<DataResponses<Purchase>> Get(Guid guid)

        {
            try
            {
                
                var res = await _EntryRepository.GetById(guid);
                return new DataResponses<Purchase>((Purchase)res,true);
            }
            catch
            {
                return new DataResponses<Purchase>();
            }
        }

        public async Task<DataResponses<Purchase>> Post(Purchase t)
        {
            try
            {
                var result = await _EntryRepository.Insert(t);

                return new DataResponses<Purchase>((Purchase)result, true);

            }
            catch
            {
                return new DataResponses<Purchase>(t, false);
            }
        }

        public async Task<DataResponses<Purchase>> Put(Purchase t)
        {
            try
            {
                var result = await _EntryRepository.Update(t);

                return new DataResponses<Purchase>((Purchase)result, true);
            }
            catch
            {
                return new DataResponses<Purchase>(t, false);
            }
        }

        public async Task<DataResponses<Purchase>> Delete(Purchase t)
        {
            try
            {
                var result = await _EntryRepository.Delete(t);

                return new DataResponses<Purchase>((Purchase)result, true);
            }
            catch
            {
                return new DataResponses<Purchase>(t, false);
            }
        }
    }
}
