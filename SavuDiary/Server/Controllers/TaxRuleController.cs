using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRuleController : ControllerBase
    {
        private ITaxRuleServices _TaxRuleRepository;

        public TaxRuleController(ITaxRuleServices TaxRuleRepository)
        {
            _TaxRuleRepository = TaxRuleRepository;
        }

        // GET: api/<TaxRuleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _TaxRuleRepository.GetAll().Result;
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

        // GET api/<TaxRuleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _TaxRuleRepository.Get(id);
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

        // POST api/<TaxRuleController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.TaxRuleModel TaxRule)
        {
            try
            {
                var result = await _TaxRuleRepository.Post(TaxRule);
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

        // PUT api/<TaxRuleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.TaxRuleModel TaxRule)
        {
            try
            {
                var result = await _TaxRuleRepository.Put(TaxRule);
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

        // DELETE api/<TaxRuleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var TaxRule = await _TaxRuleRepository.Get(id);
                if (TaxRule.Result == null)
                {
                    return NotFound();
                }
                var result = await _TaxRuleRepository.Delete(TaxRule.Result);
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
