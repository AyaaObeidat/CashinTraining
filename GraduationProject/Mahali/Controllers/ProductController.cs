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
        public async Task<IActionResult> AddAsync(ProductCreateParameters parameters) 
        { 
           await _productService.AddAsync(parameters);
           return(Ok());
        }
    }
}
