using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class TemplateServices : ITemplateServices
    {
        private readonly IRepository<TemplateEntity> _Repository;

        public TemplateServices(IRepository<TemplateEntity> repository)
        {
            _Repository = repository;
        }

        public async Task<DataResponses<IEnumerable<Template>>> GetAll()
        {
            try
            {
                
                var res = _Repository.GetAll().Select(x => (Template)x).AsEnumerable();
             
                return new DataResponses<IEnumerable<Template>>(res, true);
            }
            catch
            {
                return new DataResponses<IEnumerable<Template>>(false);
            }
        }


        public async Task<DataResponses<Template>> Get(Guid guid)

        {
            try
            {
                var res = await _Repository.GetById(guid);
                return new DataResponses<Template>((Template)res,true);
            }
            catch
            {
                return new DataResponses<Template>(false);
            }
        }

        public async Task<DataResponses<Template>> Post(Template t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses<Template>((Template)result, true);

            }
            catch
            {
                return new DataResponses<Template>(false);
            }
        }

        public async Task<DataResponses<Template>> Put(Template t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<Template>((Template)result, true);
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
                var result = await _Repository.Delete(t);

                return new DataResponses<Template>((Template)result, true);
            }
            catch
            {
                return new DataResponses<Template>(t, false);
            }
        }

        public DataResponses<IEnumerable<Template>> GetTemplateActiveAsOnDate(Guid productid, Guid customerid, DateTime date)
        {
            try
            {
                var result = _Repository.Get(x => x.ApplicableDatetime >= date && x.CustomerId == customerid && x.ProductId == productid);
                return new DataResponses<IEnumerable<Template>>( result.Select(x=> (Template)x),true);
            }
            catch
            {
                return new DataResponses<IEnumerable<Template>>(false);
            }
        }
    }
}
