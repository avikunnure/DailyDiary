using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerServices _customerRepository;

        public CustomerController(ICustomerServices customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               var result=  _customerRepository.GetAll().Result;
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch (Exception)
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
                var result =await _customerRepository.Get(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
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
                var result = await _customerRepository.Post(customer);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
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
                var result = await _customerRepository.Put(customer);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
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
                var customer = await _customerRepository.Get(id);
                if (customer.Result == null)
                {
                    return NotFound();
                }
                var result = await _customerRepository.Delete(customer.Result);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
