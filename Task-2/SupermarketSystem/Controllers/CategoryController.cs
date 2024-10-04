using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _categoryService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CategoryCreateParameters parameters)
        {
            await _categoryService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("AddProduct")]
        public async Task <IActionResult>AddProduct(CategoryUpdateParameters parameters)
        {
           await _categoryService.AddProduct(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(CategoryUpdateParameters parameters)
        {
            await _categoryService.RemoveProduct(parameters);
            return Ok();
        }
    }
    }
