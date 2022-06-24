using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.UI
{
    public class CustomerServices : IDataServices<Customer>
    {
        private readonly IRepository<CustomerEntity> _Repository;

        public CustomerServices(IRepository<CustomerEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public async Task<IEnumerable<Customer>?> GetAll(params DataParams[] objects)
        {
            try
            {
                var res= await _Repository.GetAll();
                return res.Select(x => (Customer)x);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Customer?> Get(params DataParams[] obj)
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
                var res =await _Repository.GetById(Guid.Parse(obj[0].Value?.ToString()));
                return (Customer)res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataResponses> Post(Customer t)
        {
            try
            {
                var result = await _Repository.Insert(t);
                
                    return new DataResponses((Customer)result, true);
                
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Put(Customer t, params DataParams[] dataParams)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses((Customer)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }

        public async Task<DataResponses> Delete(Customer t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses((Customer)result, true);
            }
            catch
            {
                return new DataResponses(t, false);
            }
        }
    }
}
