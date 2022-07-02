using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;
using SavuDairy.Server.Application.Interfaces;

namespace SavuDairy.Server.Application.Implementations
{
    public class SupplierServices : ISupplierServices
    {
        private readonly IRepository<SupplierEntity> _Repository;

        public SupplierServices(IRepository<SupplierEntity> customerRepository)
        {
            _Repository = customerRepository;
        }

        public Task<DataResponses<IEnumerable<Supplier>>> GetAll()
        {
            try
            {
                var res = _Repository.GetAll().Select(x => (Supplier)x).AsEnumerable();
                return Task.FromResult(new DataResponses<IEnumerable<Supplier>>(res, true));
            }
            catch
            {
                return Task.FromResult( new DataResponses<IEnumerable<Supplier>>(false));
            }
        }


        public async Task<DataResponses<Supplier>> Get(Guid guid)

        {
            try
            {
                var res = await _Repository.GetById(guid);
                return new DataResponses<Supplier>((Supplier)res,true);
            }
            catch
            {
                return new DataResponses<Supplier>(false);
            }
        }

        public async Task<DataResponses<Supplier>> Post(Supplier t)
        {
            try
            {
                var result = await _Repository.Insert(t);

                return new DataResponses<Supplier>((Supplier)result, true);

            }
            catch
            {
                return new DataResponses<Supplier>(false);
            }
        }

        public async Task<DataResponses<Supplier>> Put(Supplier t)
        {
            try
            {
                var result = await _Repository.Update(t);

                return new DataResponses<Supplier>((Supplier)result, true);
            }
            catch
            {
                return new DataResponses<Supplier>(t, false);
            }
        }

        public async Task<DataResponses<Supplier>> Delete(Supplier t)
        {
            try
            {
                var result = await _Repository.Delete(t);

                return new DataResponses<Supplier>((Supplier)result, true);
            }
            catch
            {
                return new DataResponses<Supplier>(t, false);
            }
        }
    }
}
