using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CityDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var city = await _cityService.GetByIdAsync(id);
            return Ok(city);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CityCreateParameters parameters)
        {
            await _cityService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cityService.DeleteAsync(id);
            return Ok();
        }
        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> Update(CityUpdateParameters parameters)
        {
            await _cityService.UpdateAsync(parameters);
            return Ok();
        }

    }
}
