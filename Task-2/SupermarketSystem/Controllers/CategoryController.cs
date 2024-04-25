using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.ProductDtos;
using SupermarketSystem.Repositories.Interfaces;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //=================================================================
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] CategoryCreateParameters parameters)
        {
            var category = _categoryRepository.Create(parameters);
            if (category == null) { return BadRequest(); }
            return Ok(category);
        }

        //=================================================================
        [HttpPost]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var category = _categoryRepository.Details();
            if (category == null) { return BadRequest(); }
            return Ok(category);
        }
        //=================================================================
        [HttpPost]
        [Route("GetById")]
        public IActionResult GetById(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) { return BadRequest(); }
            return Ok(category);
        }
        //=================================================================
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            int result = _categoryRepository.Delete(id);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }
        //=================================================================
       
        [HttpPatch]
        [Route("AddProduct")]
        public IActionResult AddProduct(CategoryUpdateParameters parameters)
        {
            var category = _categoryRepository.AddProduct(parameters);
            return Ok(category);
        }
        //=================================================================

        [HttpPatch]
        [Route("RemoveProduct")]
        public IActionResult RemoveProduct(CategoryUpdateParameters parameters)
        {
            var category = _categoryRepository.RemoveProduct(parameters);
            return Ok(category);
        }
    }
}
