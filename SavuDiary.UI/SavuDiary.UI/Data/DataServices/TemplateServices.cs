using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.UI.Common;
using System.Reflection;

namespace SavuDiary.UI
{
    public class TemplateServices : IDataServices<Template>
    {
        private readonly ITemplateServices _services;
        public TemplateServices(ITemplateServices services)
        {
            _services = services;
        }



        public async Task<DataResponses<IEnumerable<Template>>> GetAll(params DataParams[] objects)
        {
            try
            {
                var result = await _services.GetAll();
                return result;
            }
            catch
            {
                return null;
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<DataResponses<Template>> Get(params DataParams[] obj)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
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
                //    string MethodName = obj.Where(x=>x.Name=="MethodName").FirstOrDefault()?.Value.ToString();  
                //    var typemethod = _services.GetType().GetMethod(MethodName);
                //    var args = obj.Where(x => x.Name != "MethodName").Select(x => x.Value).ToArray();
                //    var result = typemethod.Invoke(_services, args);

                //}

                var res = await _services.Get(Guid.Parse(obj[0].Value?.ToString()));
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses<Template>> Post(Template t)
        {
            try
            {
                var result = await _services.Post(t);

                return result;

            }
            catch
            {
                return new DataResponses<Template>(t, false);
            }
        }

        public async Task<DataResponses<Template>> Put(Template t, params DataParams[] dataParams)
        {
            try
            {
                var result = await _services.Put(t);

                return result;
            }
            catch
            {
                return new DataResponses<Template>(t, false);
            }
        }

        public async Task<DataResponses<Template>> Delete(Template t)
        {
            try
            {
                var result = await _services.Delete(t);

                return result;
            }
            catch
            {
                return new DataResponses<Template>(t, false);
            }
        }

    }
}
