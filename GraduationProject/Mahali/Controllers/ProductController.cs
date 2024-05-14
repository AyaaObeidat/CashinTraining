using Mahali.Dtos.ProductDtos;
using Mahali.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahali.Controllers
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

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody]ProductCreateParameters parameters) 
        { 
           await _productService.AddAsync(parameters);
           return(Ok());
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(ProductDeleteParameters parameters)
        {
            await _productService.DeleteAsync(parameters);
            return (Ok());
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(ProductGetByParameter parameter)
        {
            return Ok(await _productService.GetByIdAsync(parameter));
        }

        [HttpPut]
        [Route("AddToCategory")]
        public async Task<IActionResult> AddToCategoryAsync(ProductGetByParameter parameter)
        {
            await _productService.AddToCategoryAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyProductName")]
        public async Task<IActionResult> ModifyProductNameAsync(ProductUpdateParameters parameter)
        {
            await _productService.ModifyProductNameAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyProductDescription")]
        public async Task<IActionResult> ModifyProductDescriptionAsync(ProductUpdateParameters parameter)
        {
            await _productService.ModifyProductDescriptionAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyProductImageUri")]
        public async Task<IActionResult> ModifyProductImageUriAsync(ProductUpdateParameters parameter)
        {
            await _productService.ModifyProductImageUriAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyProductQuantity")]
        public async Task<IActionResult> ModifyProductQuantityAsync(ProductUpdateParameters parameter)
        {
            await _productService.ModifyProductQuantityAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyProductPrice")]
        public async Task<IActionResult> ModifyProductPriceAsync(ProductUpdateParameters parameter)
        {
            await _productService.ModifyProductPriceAsync(parameter);
            return Ok();
        }

    }
}
