using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Collections.Generic;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class ProductServices: IDataServices<Product>
    {
        private HttpClient httpClient { get; set; }
        public ProductServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DataResponses<IEnumerable<Product>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var list = await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/Product");
                if(list == null)
                {
                    return new DataResponses<IEnumerable<Product>>();
                }
                return new DataResponses < IEnumerable < Product >> (list,true);
            }
            catch
            {
                return new DataResponses<IEnumerable<Product>>(false);
            }
        }

        public async Task<DataResponses<Product>> Get(params DataParams[] obj)
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
                var prod= await httpClient.GetFromJsonAsync<Product>($"/api/Product/{obj[0].Value}");
                if(prod == null)
                {
                    return new DataResponses<Product>();
                }
                return new DataResponses<Product>(prod, true);
            }
            catch
            {
                return new DataResponses<Product>();
            }
        }

        public async Task<DataResponses<Product>> Post(Product t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<Product>("/api/Product", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Product>();
                    if (null == res)
                    {
                        return new DataResponses<Product>();
                    }
                    return new DataResponses<Product>(res, true);
                }
                else
                {
                    return new DataResponses<Product>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Product>(t, false);
            }
        }

        public async Task<DataResponses<Product>> Put(Product t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<Product>($"/api/Product/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Product>();
                    if (res == null)
                    {
                        return new DataResponses<Product>();
                    }
                    return new DataResponses<Product>(res, true);
                }
                else
                {
                    return new DataResponses<Product>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Product>(t, false);
            }
        }

        public async Task<DataResponses<Product>> Delete(Product t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/Product/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<Product>();
                    if(res == null)
                    {
                        return new DataResponses<Product>();
                    }
                    return new DataResponses<Product>(res, true);
                }
                else
                {
                    return new DataResponses<Product>(t, false);
                }
            }
            catch
            {
                return new DataResponses<Product>(t, false);
            }
        }
    }
}
