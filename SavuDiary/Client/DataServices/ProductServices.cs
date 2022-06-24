using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace SavuDiary.Client
{
    public class ProductServices: IDataServices<Product>
    {
        private HttpClient httpClient { get; set; }
        public ProductServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Product>?> GetAll(params DataParams[] objects)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/Product");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Product?> Get(params DataParams[] obj)
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
                return await httpClient.GetFromJsonAsync<Product>($"/api/Product/{obj[0].Value}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Product t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<Product>("/api/Product", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Product>();
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

        public async Task<DataResponses> Put(Product t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Product>($"/api/Product/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Product>();
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

        public async Task<DataResponses> Delete(Product t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/Product/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Product>();
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
