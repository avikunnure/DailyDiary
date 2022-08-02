using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class TaxRuleModelServices : IDataServices<TaxRuleModel>
    {
        private HttpClient httpClient { get; set; }
        public TaxRuleModelServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<DataResponses< IEnumerable<TaxRuleModel>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var res= await httpClient.GetFromJsonAsync<IEnumerable<TaxRuleModel>>("/api/TaxRule");
                if (res == null)
                {
                    return new DataResponses<IEnumerable<TaxRuleModel>>();
                }
                return new DataResponses<IEnumerable<TaxRuleModel>>( res);
            }
            catch
            {
                return new DataResponses<IEnumerable<TaxRuleModel>>();
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Get(params DataParams[] obj)
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
                var res= await httpClient.GetFromJsonAsync<TaxRuleModel>($"/api/TaxRule/{obj[0].Value}");
                if(res == null)
                {
                    return new DataResponses<TaxRuleModel>();
                }
                return new DataResponses<TaxRuleModel>(res);
            }
            catch
            {
                return new DataResponses<TaxRuleModel>();
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Post(TaxRuleModel t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<TaxRuleModel>("/api/TaxRule", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadFromJsonAsync<TaxRuleModel>();
                    if (res == null)
                    {
                        return new DataResponses<TaxRuleModel>();
                    }
                    return new DataResponses<TaxRuleModel>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRuleModel>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Put(TaxRuleModel t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<TaxRuleModel>($"/api/TaxRule/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<TaxRuleModel>();
                    if (res == null)
                    {
                        return new DataResponses<TaxRuleModel>();
                    }
                    return new DataResponses<TaxRuleModel>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRuleModel>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Delete(TaxRuleModel t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/TaxRule/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<TaxRuleModel>();
                    if(res == null)
                    {
                        return new DataResponses<TaxRuleModel>();
                    }
                    return new DataResponses<TaxRuleModel>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRuleModel>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }
    }
}
