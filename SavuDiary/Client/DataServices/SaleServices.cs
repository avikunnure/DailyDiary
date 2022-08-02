using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class SaleServices: ISaleDataServices
    {
        private HttpClient httpClient { get; set; }
        public SaleServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public async Task<DataResponses< IEnumerable<Sale>>> GetAll(params DataParams[] objects)
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            try
            {
                var res = await httpClient.GetFromJsonAsync<IEnumerable<Sale>>("/api/Sale");
                if(res == null)
                {
                    return new DataResponses<IEnumerable<Sale>>();
                }
                return new DataResponses<IEnumerable<Sale>>(res);
            }
            catch
            {
                return new DataResponses<IEnumerable<Sale>>();
            }
        }

        public async Task<DataResponses<Sale>> Get(params DataParams[] obj)
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
                var res= await httpClient.GetFromJsonAsync<Sale>($"/api/Sale/{obj[0].Value}");
                if(res == null)
                {
                    return new DataResponses<Sale>();
                }
                return new DataResponses<Sale>(res);
            }
            catch
            {
                return new DataResponses<Sale>();
            }
        }

        public async Task<DataResponses<Sale>> Post(Sale t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<Sale>("/api/Sale", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Sale>();
                    if(res == null)
                    {
                        return new DataResponses<Sale>();
                    }
                    return new DataResponses<Sale>(res, true);
                }
                else
                {
                    return new DataResponses<Sale>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Sale>(t, false);
            }
        }

        public async Task<DataResponses<Sale>> Put(Sale t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Sale>($"/api/Sale/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Sale>();
                    if (res == null)
                    {
                        return new DataResponses<Sale>();
                    }
                    return new DataResponses<Sale>(res, true);
                }
                else
                {
                    return new DataResponses<Sale>(t, false);
                }
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
                var result = await httpClient.DeleteAsync($"/api/Sale/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Sale>();
                    if (res == null)
                    {
                        return new DataResponses<Sale>();
                    }
                    return new DataResponses<Sale>(res, true);
                }
                else
                {
                    return new DataResponses<Sale>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Sale>(t, false);
            }
        }

        public async Task<DataResponses<Sale>> GetSale(Guid CustomerId, DateTime date)
        {
            try
            {
                var res = await httpClient.GetFromJsonAsync<Sale>($"/api/Sale/GetSale?CustomerId={CustomerId}&date={date}");
                if (res == null)
                {
                    return new DataResponses<Sale>();
                }
                return new DataResponses<Sale>(res);
            }
            catch
            {
                return new DataResponses<Sale>(false);
            }
        }

        public async Task<DataResponses<IEnumerable<Sale>>> SaleByFilters(DateTime fromDate, DateTime toDate, Guid Customerid)
        {
            try
            {
                var res = await httpClient.GetFromJsonAsync<IEnumerable<Sale>>($"/api/Sale/GetByFilters?fromdate={fromDate}&todate={toDate}&CustomerId={Customerid}");
                if (res == null)
                {
                    return new DataResponses<IEnumerable<Sale>>();
                }
                return new DataResponses<IEnumerable<Sale>>(res);
            }
            catch
            {
                return new DataResponses<IEnumerable<Sale>>();
            }
        }
    }
}
