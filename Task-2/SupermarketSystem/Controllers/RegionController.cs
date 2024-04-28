using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.CityDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Dtos.RegionDtos;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly RegionService _regionService;

        public RegionController(RegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionService.GetAllAsync();
            return Ok(regions);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await _regionService.GetByIdAsync(id);
            return Ok(region);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] RegionCreateParameters parameters)
        {
            await _regionService.AddAsync(parameters);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _regionService.DeleteAsync(id);
            return Ok();
        }
        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> Update(RegionUpdateParameters parameters)
        {
            await _regionService.UpdateAsync(parameters);
            return Ok();
        }
    }
}
