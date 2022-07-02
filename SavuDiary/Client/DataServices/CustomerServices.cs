using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class CustomerServices : IDataServices<Customer>
    {
        private HttpClient httpClient { get; set; }
        public CustomerServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DataResponses<IEnumerable<Customer>>> GetAll(params DataParams[] objects)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<Customer>>("/api/Customer");
           if(res == null)
            {
                return new DataResponses<IEnumerable<Customer>>();
            }
            return new DataResponses<IEnumerable<Customer>>(res, true);

        }

        public async Task<DataResponses<Customer>> Get(params DataParams[] obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            if (obj.Length == 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            var cust = await httpClient.GetFromJsonAsync<Customer>($"/api/Customer/{obj[0].Value}");
            if (cust == null)
            {
                return new DataResponses<Customer>();
            }
            return new DataResponses<Customer>(cust, true);
        }

        public async Task<DataResponses<Customer>> Post(Customer t)
        {
            var result = await httpClient.PostAsJsonAsync<Customer>("/api/Customer", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Customer>();
                if(res == null)
                {
                    return new DataResponses<Customer>();
                }
                return new DataResponses<Customer>(res, true);
            }
            else
            {
                return new DataResponses<Customer>(t, false);
            }
        }

        public async Task<DataResponses<Customer>> Put(Customer t, params DataParams[] dataParams)
        {
            var result = await httpClient.PutAsJsonAsync<Customer>($"/api/Customer/{t.Id}", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Customer>();
                if (res == null)
                {
                    return new DataResponses<Customer>();
                }
                return new DataResponses<Customer>(res, true);
            }
            else
            {
                return new DataResponses<Customer>(t, false);
            }
        }

        public async Task<DataResponses<Customer>> Delete(Customer t)
        {
            var result = await httpClient.DeleteAsync($"/api/Customer/{t.Id}");
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Customer>();
                if( res == null)
                {
                    return new DataResponses<Customer>();
                }
                return new DataResponses<Customer>(res, true);
            }
            else
            {
                return new DataResponses<Customer>(t, false);
            }
        }
    }
}
