using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class TaxRecordDetailsServices : IDataServices<TaxRecordDetails>
    {
        private HttpClient httpClient { get; set; }
        public TaxRecordDetailsServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<DataResponses< IEnumerable<TaxRecordDetails>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var res= await httpClient.GetFromJsonAsync<IEnumerable<TaxRecordDetails>>("/api/TaxRecordDetails");
                if (res == null)
                {
                    return new DataResponses<IEnumerable<TaxRecordDetails>>();
                }
                return new DataResponses<IEnumerable<TaxRecordDetails>>( res);
            }
            catch
            {
                return new DataResponses<IEnumerable<TaxRecordDetails>>();
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Get(params DataParams[] obj)
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
                var res= await httpClient.GetFromJsonAsync<TaxRecordDetails>($"/api/TaxRecordDetails/{obj[0].Value}");
                if(res == null)
                {
                    return new DataResponses<TaxRecordDetails>();
                }
                return new DataResponses<TaxRecordDetails>(res);
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>();
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Post(TaxRecordDetails t)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<TaxRecordDetails>("/api/TaxRecordDetails", t);
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadFromJsonAsync<TaxRecordDetails>();
                    if (res == null)
                    {
                        return new DataResponses<TaxRecordDetails>();
                    }
                    return new DataResponses<TaxRecordDetails>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRecordDetails>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Put(TaxRecordDetails t, params DataParams[] dataParams)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync<TaxRecordDetails>($"/api/TaxRecordDetails/{t.Id}", t);
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<TaxRecordDetails>();
                    if (res == null)
                    {
                        return new DataResponses<TaxRecordDetails>();
                    }
                    return new DataResponses<TaxRecordDetails>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRecordDetails>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }

        public async Task<DataResponses<TaxRecordDetails>> Delete(TaxRecordDetails t)
        {
            try
            {
                var result = await httpClient.DeleteAsync($"/api/TaxRecordDetails/{t.Id}");
                if (result.IsSuccessStatusCode)
                {
                    var res =await result.Content.ReadFromJsonAsync<TaxRecordDetails>();
                    if(res == null)
                    {
                        return new DataResponses<TaxRecordDetails>();
                    }
                    return new DataResponses<TaxRecordDetails>(res, true);
                }
                else
                {
                    return new DataResponses<TaxRecordDetails>(t, false);
                }
            }
            catch
            {
                return new DataResponses<TaxRecordDetails>(t, false);
            }
        }
    }
}
