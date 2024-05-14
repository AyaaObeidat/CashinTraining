using Mahali.Dtos.CategoryDtos;
using Mahali.Repositories.Implementations;
using Mahali.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahali.Controllers
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

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody]CategoryCreateParameters parameters)
        {
            await _categoryService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(CategoryDeleteParameters parameters)
        {
            await _categoryService.DeleteAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> ModifyNameAsync(CategoryUpdateParameters parameters)
        {
            await _categoryService.ModifyCategoryNameAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            await _categoryService.GetAllAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(CategoryGetByParameter parameter)
        {
            await _categoryService.GetByIdAsync(parameter);
            return Ok();
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetCategoryProductsAsync(CategoryGetByParameter parameter)
        {
            await _categoryService.GetCategoryProductsAsync(parameter);
            return Ok();
        }
    }
}
