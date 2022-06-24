using Microsoft.AspNetCore.Mvc;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private IRepository<SaleEntity> _saleRepository;
        private IRepository<SaleEntry> _Repository;

        public SaleController(IRepository<SaleEntity> saleRepository, IRepository<SaleEntry> repository)
        {
            _saleRepository = saleRepository;
            _Repository = repository;
        }

        // GET: api/<SaleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var result= await _saleRepository.GetAll();
                return Ok(result.Select(x=>(Shared.Sale)x));
            }catch (Exception)
            {
                throw;
            }
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public  async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result =await _saleRepository.GetById(id);
                return Ok(result);
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
                var result = await _Repository.Insert((SaleEntry) sale);
                return Ok(result);
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
                var result = await _Repository.Update((SaleEntry) sale);
                return Ok(result);
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
                var sale = await _Repository.GetById(id);
                var result = await _Repository.Delete(sale);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
