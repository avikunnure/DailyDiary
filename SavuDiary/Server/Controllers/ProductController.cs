using Microsoft.AspNetCore.Mvc;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<ProductEntity> _productRepository;

        public ProductController(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var result= await _productRepository.GetAll();
                return Ok(result.Select(x=>(Shared.Product)x));
            }catch (Exception ex)
            {
                throw;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public  async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result =(Shared.Product) await _productRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post(Shared.Product product)
        {
            try
            {
                var result = await _productRepository.Insert((ProductEntity) product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Shared.Product product)
        {
            try
            {
                var result = await _productRepository.Update((ProductEntity) product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var product = await _productRepository.GetById(id);
                var result = await _productRepository.Delete(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
