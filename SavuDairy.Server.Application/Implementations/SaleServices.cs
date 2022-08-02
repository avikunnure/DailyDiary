using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class SaleServices : ISaleServices
    {
        private readonly ISaleRepository _Repository;
        private readonly IRepository<SaleEntry> _EntryRepository;

        public SaleServices(ISaleRepository repository, IRepository<SaleEntry> entryRepository)
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

        public async Task< DataResponses< Sale>> GetSale(Guid CustomerId, DateTime date)
        {
            var result = new Sale();
            var s=_Repository.GetSale(CustomerId, date);
            if (s.Id != Guid.Empty)
            {
                result = await _EntryRepository.GetById(s.Id);
            }
            else
            {
                result=(Sale)s;
            }
            return  new DataResponses<Sale>(result,true);
        }

        public DataResponses< IEnumerable<Sale>> SaleByFilters(DateTime fromDate, DateTime toDate, Guid Customerid)
        {
            try
            {
                var res = _Repository.SaleByFilters(fromDate,toDate,Customerid).Select(x => (Sale)x).AsEnumerable();
                return new DataResponses<IEnumerable<Sale>>(res, true);
            }
            catch
            {
                return new DataResponses<IEnumerable<Sale>>(false);
            }
        }
    }
}
