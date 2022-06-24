using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.UI
{
    public class SaleServices : IDataServices<Sale>
    {
        private readonly IRepository<SaleEntity> _Repository;

        public SaleServices(IRepository<SaleEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public async Task<IEnumerable<Sale>?> GetAll(params DataParams[] objects)
        {
            try
            {
                var res = await _Repository.GetAll();
                return res.Select(x => (Sale)x);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Sale?> Get(params DataParams[] obj)
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
                var res = await _Repository.GetById(Guid.Parse(obj[0].Value?.ToString()));
                return (Sale)res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Sale t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses((Sale)result, true);

            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Put(Sale t, params DataParams[] dataParams)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses((Sale)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Delete(Sale t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses((Sale)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }
    }
}
