using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<ProductEntity> _Repository;

        public ProductServices(IRepository<ProductEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public Task<DataResponses<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (Product)x).AsEnumerable();
                return Task.FromResult(new DataResponses<IEnumerable<Product>>(res, true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<Product>>());
            }
        }


        public async Task<DataResponses<Product>> Get(Guid guid)

        {
            try
            {
                var res = await _Repository.GetById(guid);
                return new DataResponses<Product>((Product)res,true);
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
                var result = await _Repository.Insert(t);

                return new DataResponses<Product>((Product)result, true);

            }
            catch
            {
                return new DataResponses<Product>(t, false);
            }
        }

        public async Task<DataResponses<Product>> Put(Product t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<Product>((Product)result, true);
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
                var result = await _Repository.Delete(t);

                return new DataResponses<Product>((Product)result, true);
            }
            catch
            {
                return new DataResponses<Product>(t, false);
            }
        }
    }
}
