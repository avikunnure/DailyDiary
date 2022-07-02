using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseServices _purchaseRepository;

        public PurchaseController(IPurchaseServices purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        // GET: api/<PurchaseController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _purchaseRepository.GetAll().Result;
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

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _purchaseRepository.Get(id);
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

        // POST api/<PurchaseController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Purchase purchase)
        {
            try
            {
                var result = await _purchaseRepository.Post(purchase);
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

        // PUT api/<PurchaseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Purchase purchase)
        {
            try
            {
                var result = await _purchaseRepository.Put(purchase);
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

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var purchase = await _purchaseRepository.Get(id);
                if (purchase.Result == null)
                {
                    return NotFound();
                }
                var result = await _purchaseRepository.Delete(purchase.Result);
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
