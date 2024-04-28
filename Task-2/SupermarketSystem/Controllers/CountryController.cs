using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CategoryDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var country = await _countryService.GetByIdAsync(id);
            return Ok(country);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CountryCreateParameters parameters)
        {
            await _countryService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> Update(CountryUpdateParameters parameters)
        {
            await _countryService.UpdateAsync(parameters);
            return Ok();
        }
    }
}
