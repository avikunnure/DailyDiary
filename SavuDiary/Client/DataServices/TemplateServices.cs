using SavuDiary.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public class TemplateServices : IDataServices<Template>
    {
        private HttpClient httpClient { get; set; }
        public TemplateServices(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DataResponses<IEnumerable<Template>>> GetAll(params DataParams[] objects)
        {
            var res = await httpClient.GetFromJsonAsync<IEnumerable<Template>>("/api/Template");
           if(res == null)
            {
                return new DataResponses<IEnumerable<Template>>();
            }
            return new DataResponses<IEnumerable<Template>>(res, true);
        }

        public async Task<DataResponses<Template>> Get(params DataParams[] obj)
        {
            bool isNotFound = false;
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (obj.Length == 0)
            {
                isNotFound = true;
            }
            else if (obj[0].Value == null)
            {
                isNotFound = true;
            }
            
            if (isNotFound)
            {
                throw new ArgumentException(nameof(obj));
            }
            //if (obj.Where(x => x.Name == "MethodName").Count() > 0)
            //{
            //    string MethodName = obj.Where(x => x.Name == "MethodName").FirstOrDefault()?.Value.ToString();
            //    if (obj.Where(x => x.Name != "MethodName").Count() > 0) {
            //        MethodName += "?";
            //        var list = obj.Where(x => x.Name != "MethodName").ToArray();
            //        for (int i = 0; i < list.Count(); i++)
            //        {
            //            MethodName += $"{list[i].Name}={list[i].Value}";
            //            if (i + 1 < list.Count())
            //            {
            //                MethodName += "&";
            //            }
            //        }
            //    }
            //    var cust1 = await httpClient.GetFromJsonAsync<IEnumerable<Template>>($"/api/Template/{MethodName}");
            //    if (cust1 == null)
            //    {
            //        return new DataResponses<Template>();
            //    }
            //}

            var cust = await httpClient.GetFromJsonAsync<Template>($"/api/Template/{obj[0].Value}");
            if (cust == null)
            {
                return new DataResponses<Template>();
            }
            return new DataResponses<Template>(cust, true);
        }

        public async Task<DataResponses<Template>> Post(Template t)
        {
            var result = await httpClient.PostAsJsonAsync<Template>("/api/Template", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Template>();
                if(res == null)
                {
                    return new DataResponses<Template>();
                }
                return new DataResponses<Template>(res, true);
            }
            else
            {
                var res = await result.Content.ReadAsStringAsync();
                return new DataResponses<Template>(t, false);
            }
        }

        public async Task<DataResponses<Template>> Put(Template t, params DataParams[] dataParams)
        {
            var result = await httpClient.PutAsJsonAsync<Template>($"/api/Template/{t.Id}", t);
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Template>();
                if (res == null)
                {
                    return new DataResponses<Template>();
                }
                return new DataResponses<Template>(res, true);
            }
            else
            {
                return new DataResponses<Template>(t, false);
            }
        }

        public async Task<DataResponses<Template>> Delete(Template t)
        {
            var result = await httpClient.DeleteAsync($"/api/Template/{t.Id}");
            if (result.IsSuccessStatusCode)
            {
                var res = await result.Content.ReadFromJsonAsync<Template>();
                if( res == null)
                {
                    return new DataResponses<Template>();
                }
                return new DataResponses<Template>(res, true);
            }
            else
            {
                return new DataResponses<Template>(t, false);
            }
        }
    }
}
