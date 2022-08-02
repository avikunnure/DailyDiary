using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class TaxRecordDetailsServices : ITaxRecordDetailsServices
    {
        private readonly IRepository<TaxRecordDetailEntity> _Repository;

        public TaxRecordDetailsServices(IRepository<TaxRecordDetailEntity> repository)
        {
            _Repository = repository;
        }

        public Task<DataResponses<IEnumerable<TaxRecordDetails>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (TaxRecordDetails)x).AsEnumerable();
                return Task.FromResult(new DataResponses<IEnumerable<TaxRecordDetails>>(res, true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<TaxRecordDetails>>());
            }
        }


        public async Task<DataResponses<TaxRecordDetails>> Get(Guid guid)

        {
            try
            {
                var res = await _Repository.GetById(guid);
                return new DataResponses<TaxRecordDetails>((TaxRecordDetails)res,true);
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>();
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Post(TaxRecordDetails t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses<TaxRecordDetails>((TaxRecordDetails)result, true);

            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Put(TaxRecordDetails t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<TaxRecordDetails>((TaxRecordDetails)result, true);
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Delete(TaxRecordDetails t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses<TaxRecordDetails>((TaxRecordDetails)result, true);
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }
    }
}
