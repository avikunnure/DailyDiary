using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRecordDetailsController : ControllerBase
    {
        private ITaxRecordDetailsServices _TaxRecordDetailsRepository;

        public TaxRecordDetailsController(ITaxRecordDetailsServices TaxRecordDetailsRepository)
        {
            _TaxRecordDetailsRepository = TaxRecordDetailsRepository;
        }

        // GET: api/<TaxRecordDetailsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _TaxRecordDetailsRepository.GetAll().Result;
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

        // GET api/<TaxRecordDetailsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _TaxRecordDetailsRepository.Get(id);
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

        // POST api/<TaxRecordDetailsController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.TaxRecordDetails TaxRecordDetails)
        {
            try
            {
                var result = await _TaxRecordDetailsRepository.Post(TaxRecordDetails);
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

        // PUT api/<TaxRecordDetailsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.TaxRecordDetails TaxRecordDetails)
        {
            try
            {
                var result = await _TaxRecordDetailsRepository.Put(TaxRecordDetails);
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

        // DELETE api/<TaxRecordDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var TaxRecordDetails = await _TaxRecordDetailsRepository.Get(id);
                if (TaxRecordDetails.Result == null)
                {
                    return NotFound();
                }
                var result = await _TaxRecordDetailsRepository.Delete(TaxRecordDetails.Result);
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
