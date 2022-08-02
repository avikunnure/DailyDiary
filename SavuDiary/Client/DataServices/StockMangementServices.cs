using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class StockMangementServices : IStockDataServices
    {
        private HttpClient httpClient { get; set; }
        public StockMangementServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DataResponses<IEnumerable<StockMangement>>> GetAll(params DataParams[] objects)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<StockMangement>>("/api/StockManagement");
           if(res == null)
            {
                return new DataResponses<IEnumerable<StockMangement>>();
            }
            return new DataResponses<IEnumerable<StockMangement>>(res, true);

        }

        public async Task<DataResponses<StockMangement>> Get(params DataParams[] obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            if (obj.Length == 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            var cust = await httpClient.GetFromJsonAsync<StockMangement>($"/api/StockManagement/{obj[0].Value}");
            if (cust == null)
            {
                return new DataResponses<StockMangement>();
            }
            return new DataResponses<StockMangement>(cust, true);
        }

        public async Task<DataResponses<StockMangement>> Post(StockMangement t)
        {
            var result = await httpClient.PostAsJsonAsync<StockMangement>("/api/StockManagement", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<StockMangement>();
                if(res == null)
                {
                    return new DataResponses<StockMangement>();
                }
                return new DataResponses<StockMangement>(res, true);
            }
            else
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task<DataResponses<StockMangement>> Put(StockMangement t, params DataParams[] dataParams)
        {
            var result = await httpClient.PutAsJsonAsync<StockMangement>($"/api/StockManagement/{t.Id}", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<StockMangement>();
                if (res == null)
                {
                    return new DataResponses<StockMangement>();
                }
                return new DataResponses<StockMangement>(res, true);
            }
            else
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task<DataResponses<StockMangement>> Delete(StockMangement t)
        {
            var result = await httpClient.DeleteAsync($"/api/StockManagement/{t.Id}");
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<StockMangement>();
                if( res == null)
                {
                    return new DataResponses<StockMangement>();
                }
                return new DataResponses<StockMangement>(res, true);
            }
            else
            {
                return new DataResponses<StockMangement>(t, false);
            }
        }

        public async Task< DataResponses<IEnumerable<StockMangement>>> GetStockMangements(DateTime date, Guid? productid)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<StockMangement>>($"/api/StockManagement/GetStocks?date={date}&productid={productid}");
            if (res == null)
            {
                return new DataResponses<IEnumerable<StockMangement>>();
            }
            return new DataResponses<IEnumerable<StockMangement>>(res, true);
        }
    }
}
