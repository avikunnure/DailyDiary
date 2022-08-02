using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class StockMangementServices : IStockManagementServices
    {
        private readonly IStockManagementRepository _Repository;
       
        public StockMangementServices(IStockManagementRepository repository)
        {
            _Repository = repository;
        }

        public Task<DataResponses<IEnumerable<StockMangement>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (StockMangement)x).AsEnumerable();
                return Task.FromResult( new DataResponses<IEnumerable<StockMangement>>(res,true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<StockMangement>>(false));
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<DataResponses<StockMangement>> Get(Guid id)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
            {
               
                var res = await _Repository.GetById(id);
                return new DataResponses<StockMangement>((StockMangement)res,true);
            }
            catch
            {
                return new DataResponses<StockMangement>( false); ;
            }
        }

        public async Task<DataResponses<StockMangement>> Post(StockMangement t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses<StockMangement>((StockMangement)result, true);

            }
            catch
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task<DataResponses<StockMangement>> Put(StockMangement t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<StockMangement>((StockMangement)result, true);
            }
            catch
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task<DataResponses<StockMangement>> Delete(StockMangement t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses<StockMangement>((StockMangement)result, true);
            }
            catch
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public DataResponses<IEnumerable<StockMangement>> CurrentStockOnDate(DateTime fromDate, Guid? ProductId = null)
        {
            try
            {
                var res = _Repository.CurrentStockOnDate(fromDate,ProductId).Select(x => (StockMangement)x);
                return new DataResponses<IEnumerable<StockMangement>>(res, true);
            }
            catch
            {
                return new DataResponses<IEnumerable<StockMangement>>(false);
            }
        }
    }
}
