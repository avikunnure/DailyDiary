using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;
using SavuDiary.Shared;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockManagementController : ControllerBase
    {
        private IStockManagementServices _stockManagementRepository;

        public StockManagementController(IStockManagementServices stockManagementRepository)
        {
            _stockManagementRepository = stockManagementRepository;
        }

        // GET: api/<StockManagementController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _stockManagementRepository.GetAll().Result;
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
        [HttpGet("GetStocks")]
        public IActionResult GetStocks(DateTime date,Guid? productid=null)
        {
            try
            {
                var result =  _stockManagementRepository.CurrentStockOnDate(date,productid);
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

        // GET api/<StockManagementController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _stockManagementRepository.Get(id);
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

        // POST api/<StockManagementController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.StockMangement stockManagement)
        {
            try
            {
                var result = await _stockManagementRepository.Post(stockManagement);
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

        // PUT api/<StockManagementController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.StockMangement stockManagement)
        {
            try
            {
                var result = await _stockManagementRepository.Put(stockManagement);
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

        // DELETE api/<StockManagementController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var stockManagement = await _stockManagementRepository.Get(id);
                if (stockManagement.Result == null)
                {
                    return NotFound();
                }
                var result = await _stockManagementRepository.Delete(stockManagement.Result);
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
