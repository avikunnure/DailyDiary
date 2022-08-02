using Microsoft.AspNetCore.Mvc;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ITemplateServices _templateRepository;

        public TemplateController(ITemplateServices templateRepository)
        {
            _templateRepository = templateRepository;
        }

        // GET: api/<TemplateController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var result=await  _templateRepository.GetAll();
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

        // GET: api/<TemplateController>
        [HttpGet("GetTemplateActiveAsOnDate")]
        public IActionResult GetTemplateActiveAsOnDate(Guid productid,Guid customerid,DateTime date)
        {
            try
            {
                var result = _templateRepository.GetTemplateActiveAsOnDate(productid,customerid,date);
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


        // GET api/<TemplateController>/5
        [HttpGet("{id}")]
        public  async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result =await _templateRepository.Get(id);
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

        // POST api/<TemplateController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Template template)
        {
            try
            {
                if (ModelState.IsValid != true)
                {
                    return BadRequest(ModelState);
                }

                var result = await _templateRepository.Post(template);
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

        // PUT api/<TemplateController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Template template)
        {
            try
            {
                var result = await _templateRepository.Put(template);
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

        // DELETE api/<TemplateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var template = await _templateRepository.Get(id);
                if (template.Result == null)
                {
                    return NotFound();
                }
                var result = await _templateRepository.Delete(template.Result);
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
