using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISaleServices _saleRepository;

        public SaleController(ISaleServices saleRepository)
        {
            _saleRepository = saleRepository;
        }

        // GET: api/<SaleController>
        [HttpGet("GetSale")]
        public IActionResult GetSale(Guid CustomerId,DateTime date)
        {
            try
            {
                var result = _saleRepository.GetSale(CustomerId,date).Result;
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


        // GET: api/<SaleController>
        [HttpGet("GetByFilters")]
        public IActionResult GetByFilters(DateTime fromdate,DateTime todate,Guid CustomerId)
        {
            try
            {
                var result = _saleRepository.SaleByFilters(fromdate,todate,CustomerId).Result;
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // GET: api/<SaleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _saleRepository.GetAll().Result;
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

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _saleRepository.Get(id);
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

        // POST api/<SaleController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Sale sale)
        {
            try
            {
                var result = await _saleRepository.Post(sale);
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

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Sale sale)
        {
            try
            {
                var result = await _saleRepository.Put(sale);
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

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var sale = await _saleRepository.Get(id);
                if (sale.Result == null)
                {
                    return NotFound();
                }
                var result = await _saleRepository.Delete(sale.Result);
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
