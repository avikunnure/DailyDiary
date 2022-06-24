using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.UI
{
    public class ProductServices : IDataServices<Product>
    {
        private readonly IRepository<ProductEntity> _Repository;

        public ProductServices(IRepository<ProductEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public async Task<IEnumerable<Product>?> GetAll(params DataParams[] objects)
        {
            try
            {
                var res = await _Repository.GetAll();
                return res.Select(x => (Product)x);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Product?> Get(params DataParams[] obj)
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
                return (Product)res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Product t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses((Product)result, true);

            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Put(Product t, params DataParams[] dataParams)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses((Product)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Delete(Product t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses((Product)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }
    }
}
