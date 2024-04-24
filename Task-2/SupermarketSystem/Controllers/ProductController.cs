using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //=================================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody]ProductCreateParameters parameters)
        {
            var product = _productRepository.Create(parameters);
            if (product == null) { return BadRequest(); }
            return Ok(product);
        }

        //=================================================================
        [HttpPost]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var products = _productRepository.Details();
            if (products == null) { return BadRequest(); }
            return Ok(products);
        }
        //=================================================================
        [HttpPost]
        [Route("GetById")]
        public IActionResult GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product  == null) { return BadRequest(); }
            return Ok(product);
        }
        //=================================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            int result = _productRepository.Delete(id);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }
        //=================================================================
        [HttpPatch]
        [Route("UpdatePrice")]
        public IActionResult UpdatePrice(ProductUpdateParameters parameters)
        {
            _productRepository.UpdatePrice(parameters);
             return Ok();
        }
        //=================================================================
        [HttpPatch]
        [Route("UpdateQuantity")]
        public IActionResult UpdateQuantity(ProductUpdateParameters parameters)
        {
            _productRepository.UpdateQuantity(parameters);
            return Ok();
        }
        //=================================================================
        [HttpPatch]
        [Route("UpdateCategoryId")]
        public IActionResult UpdateCategoryId(ProductUpdateParameters parameters)
        {
            _productRepository.UpdateCategoryId(parameters);
            return Ok();
        }
    }
}
