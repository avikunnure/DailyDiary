using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class PurchaseServices : IDataServices<Purchase>
    {
        private HttpClient httpClient { get; set; }
        public PurchaseServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<DataResponses< IEnumerable<Purchase>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var res= await httpClient.GetFromJsonAsync<IEnumerable<Purchase>>("/api/Purchase");
                if (res == null)
                {
                    return new DataResponses<IEnumerable<Purchase>>();
                }
                return new DataResponses<IEnumerable<Purchase>>( res);
            }
            catch
            {
                return new DataResponses<IEnumerable<Purchase>>();
            }
        }

        public async Task<DataResponses<Purchase>> Get(params DataParams[] obj)
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
                var res= await httpClient.GetFromJsonAsync<Purchase>($"/api/Purchase/{obj[0].Value}");
                if(res == null)
                {
                    return new DataResponses<Purchase>();
                }
                return new DataResponses<Purchase>(res);
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
                var result = await httpClient.PostAsJsonAsync<Purchase>("/api/Purchase", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadFromJsonAsync<Purchase>();
                    if (res == null)
                    {
                        return new DataResponses<Purchase>();
                    }
                    return new DataResponses<Purchase>(res, true);
                }
                else
                {
                    var stringresult=await result.Content.ReadAsStringAsync();
                    return new DataResponses<Purchase>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Purchase>(t, false);
            }
        }

        public async Task<DataResponses<Purchase>> Put(Purchase t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Purchase>($"/api/Purchase/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Purchase>();
                    if (res == null)
                    {
                        return new DataResponses<Purchase>();
                    }
                    return new DataResponses<Purchase>(res, true);
                }
                else
                {
                    return new DataResponses<Purchase>(t, false);
                }
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
                var result = await httpClient.DeleteAsync($"/api/Purchase/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Purchase>();
                    if(res == null)
                    {
                        return new DataResponses<Purchase>();
                    }
                    return new DataResponses<Purchase>(res, true);
                }
                else
                {
                    return new DataResponses<Purchase>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Purchase>(t, false);
            }
        }
    }
}
