using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierServices _customerRepository;

        public SupplierController(ISupplierServices customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<SupplierController>
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

        // GET api/<SupplierController>/5
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

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Supplier customer)
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

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Supplier customer)
        {
            try
            {
                var result = await _customerRepository.Put( customer);
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

        // DELETE api/<SupplierController>/5
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
