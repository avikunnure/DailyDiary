using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace SavuDiary.Client
{
    public class SaleServices: IDataServices<Sale>
    {
        private HttpClient httpClient { get; set; }
        public SaleServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Sale>?> GetAll(params DataParams[] objects)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<Sale>>("/api/Sale");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Sale?> Get(params DataParams[] obj)
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
                return await httpClient.GetFromJsonAsync<Sale>($"/api/Sale/{obj[0].Value}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Sale t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<Sale>("/api/Sale", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Sale>();
                    return new DataResponses(res, true);
                }
                else
                {
                    return new DataResponses(t, false);
                }
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Put(Sale t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Sale>($"/api/Sale/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Sale>();
                    return new DataResponses(res, true);
                }
                else
                {
                    return new DataResponses(t, false);
                }
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Delete(Sale t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/Sale/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Sale>();
                    return new DataResponses(res, true);
                }
                else
                {
                    return new DataResponses(t, false);
                }
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }
    }
}
