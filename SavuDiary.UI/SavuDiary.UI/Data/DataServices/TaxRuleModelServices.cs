using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.UI.Common;

namespace SavuDiary.UI
{
    public class TaxRuleModelServices : IDataServices<TaxRuleModel>
    {
        private readonly ITaxRuleServices _services;
        public TaxRuleModelServices(ITaxRuleServices services)
        {
            _services = services;
        }

        public async Task< DataResponses< IEnumerable<TaxRuleModel>>> GetAll(params DataParams[] objects)
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
        public async Task<DataResponses<TaxRuleModel>> Get(params DataParams[] obj)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
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
                if (obj[0].Value == null)
                {
                    throw new ArgumentOutOfRangeException("id");
                }
                var res = await _services.Get(Guid.Parse(obj[0].Value?.ToString()));
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses<TaxRuleModel>> Post(TaxRuleModel t)
        {
            try
            {
                var result = await _services.Post(t);

                return result;

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
                var result = await _services.Put(t);

                return result;
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
                var result = await _services.Delete(t);

                return result;
            }
            catch
            {
                return new DataResponses<TaxRuleModel>(t, false);
            }
        }
    }
}
