using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace SavuDiary.Client
{
    public class CustomerServices : IDataServices<Customer>
    {
        private HttpClient httpClient { get; set; }
        public CustomerServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Customer>?> GetAll(params DataParams[] objects)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<Customer>>("/api/Customer");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Customer?> Get(params DataParams[] obj)
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
                return await httpClient.GetFromJsonAsync<Customer>($"/api/Customer/{obj[0].Value}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Customer t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<Customer>("/api/Customer", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Customer>();
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

        public async Task<DataResponses> Put(Customer t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Customer>($"/api/Customer/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Customer>();
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

        public async Task<DataResponses> Delete(Customer t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/Customer/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadFromJsonAsync<Customer>();
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
