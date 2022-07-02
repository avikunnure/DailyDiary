using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<CustomerEntity> _Repository;

        public CustomerServices(IRepository<CustomerEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public Task<DataResponses<IEnumerable<Customer>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (Customer)x).AsEnumerable();
                return Task.FromResult(new DataResponses<IEnumerable<Customer>>(res, true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<Customer>>(false));
            }
        }


        public async Task<DataResponses<Customer>> Get(Guid guid)

        {
            try
            {
                var res = await _Repository.GetById(guid);
                return new DataResponses<Customer>((Customer)res,true);
            }
            catch
            {
                return new DataResponses<Customer>(false);
            }
        }

        public async Task<DataResponses<Customer>> Post(Customer t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses<Customer>((Customer)result, true);

            }
            catch
            {
                return new DataResponses<Customer>(false);
            }
        }

        public async Task<DataResponses<Customer>> Put(Customer t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<Customer>((Customer)result, true);
            }
            catch
            {
                return new DataResponses<Customer>(t, false);
            }
        }

        public async Task<DataResponses<Customer>> Delete(Customer t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses<Customer>((Customer)result, true);
            }
            catch
            {
                return new DataResponses<Customer>(t, false);
            }
        }
    }
}
