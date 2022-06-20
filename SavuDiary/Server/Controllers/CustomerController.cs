using Microsoft.AspNetCore.Mvc;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IRepository<CustomerEntity> _customerRepository;

        public CustomerController(IRepository<CustomerEntity> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var result= await _customerRepository.GetAll();
                return Ok(result.Select(x=>(Shared.Customer)x));
            }catch (Exception)
            {
                throw;
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public  async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result =(Shared.Customer) await _customerRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Customer customer)
        {
            try
            {
                var result = await _customerRepository.Insert((CustomerEntity) customer);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Customer customer)
        {
            try
            {
                var result = await _customerRepository.Update((CustomerEntity) customer);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var customer = await _customerRepository.GetById(id);
                var result = await _customerRepository.Delete(customer);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
