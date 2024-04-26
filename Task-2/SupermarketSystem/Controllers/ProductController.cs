using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Repositories.Implementations;
using SupermarketSystem.Repositories.Interfaces;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody]ProductCreateParameters parameters)
        {
            await _productService.AddAsync(parameters);
            return Ok();    
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdatePrice")]
        public async Task< IActionResult> UpdatePrice([FromBody] ProductUpdateParameters parameters)
        {
            await _productService.UpdatePrice(parameters);
            return Ok();
        }
       

        [HttpPatch]
        [Route("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] ProductUpdateParameters parameters)
        {
            await _productService.UpdateQuantity(parameters);
            return Ok();
        }
    }
}
