using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.UI.Common;

namespace SavuDiary.UI
{
    public class StockMangementServices : IStockDataServices
    {
        private readonly IStockManagementServices _services;
        public StockMangementServices(IStockManagementServices services)
        {
            _services = services;
        }

        public async Task< DataResponses< IEnumerable<StockMangement>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var result = await _services.GetAll();
                return result;
            }
            catch
            {
                return null;
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<DataResponses<StockMangement>> Get(params DataParams[] obj)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }
                if (obj.Length == 0)
                {
                    throw new ArgumentOutOfRangeException("id");
                }
                if (obj[0].Value == null)
                {
                    throw new ArgumentOutOfRangeException("id");
                }
                var res = await _services.Get(Guid.Parse(obj[0].Value?.ToString()));
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses<StockMangement>> Post(StockMangement t)
        {
            try
            {
                var result = await _services.Post(t);

                return result;

            }
            catch
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task<DataResponses<StockMangement>> Put(StockMangement t, params DataParams[] dataParams)
        {
            try
            {
                var result = await _services.Put(t);

                return result;
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
                var result = await _services.Delete(t);

                return result;
            }
            catch
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }


        public Task<DataResponses<IEnumerable<StockMangement>>> GetStockMangements(DateTime date, Guid? productid)
        {
            try
            {
                var result = _services.CurrentStockOnDate(date, productid);
                return Task.FromResult(result);
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<StockMangement>>(false));
            }
        }
    }
}
