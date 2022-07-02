using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class SupplierServices : IDataServices<Supplier>
    {
        private HttpClient httpClient { get; set; }
        public SupplierServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DataResponses<IEnumerable<Supplier>>> GetAll(params DataParams[] objects)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<Supplier>>("/api/Supplier");
            if(res == null)
            {
                return new DataResponses<IEnumerable<Supplier>>();
            }
            return new DataResponses<IEnumerable<Supplier>>(res, true);

        }

        public async Task<DataResponses<Supplier>> Get(params DataParams[] obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            if (obj.Length == 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            var cust = await httpClient.GetFromJsonAsync<Supplier>($"/api/Supplier/{obj[0].Value}");
            if(cust == null)
            {
                return new DataResponses<Supplier>();
            }
            return new DataResponses<Supplier>(cust, true);
        }

        public async Task<DataResponses<Supplier>> Post(Supplier t)
        {
            var result = await httpClient.PostAsJsonAsync<Supplier>("/api/Supplier", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Supplier>();
                if(res == null)
                {
                    return new DataResponses<Supplier>();
                }
                return new DataResponses<Supplier>(res, true);
            }
            else
            {
                return new DataResponses<Supplier>(t, false);
            }
        }

        public async Task<DataResponses<Supplier>> Put(Supplier t, params DataParams[] dataParams)
        {
            var result = await httpClient.PutAsJsonAsync<Supplier>($"/api/Supplier/{t.Id}", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Supplier>();
                if(res == null)
                {
                    return new DataResponses<Supplier>();
                }
                return new DataResponses<Supplier>(res, true);
            }
            else
            {
                return new DataResponses<Supplier>(t, false);
            }
        }

        public async Task<DataResponses<Supplier>> Delete(Supplier t)
        {
            var result = await httpClient.DeleteAsync($"/api/Supplier/{t.Id}");
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Supplier>();
                if (res == null)
                {
                    return new DataResponses<Supplier>();
                }
                return new DataResponses<Supplier>(res, true);
            }
            else
            {
                return new DataResponses<Supplier>(t, false);
            }
        }
    }
}
