using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSystem.Dtos.AddressDtos;
using SupermarketSystem.Dtos.CountryDtos;
using SupermarketSystem.Services;

namespace SupermarketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        //address
            private readonly AddressService _addressService;

            public AddressController(AddressService addressService)
            {
            _addressService = addressService;

            }

            [HttpGet]
            [Route("GetAll")]
            public async Task<IActionResult> GetAll()
            {
                var addresses = await _addressService.GetAllAsync();
                return Ok(addresses);
            }

            [HttpGet]
            [Route("GetById")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var address = await _addressService.GetByIdAsync(id);
                return Ok(address);
            }

            [HttpPost]
            [Route("Add")]
            public async Task<IActionResult> Add([FromBody] AddressCreateParameters parameters)
            {
                await _addressService.AddAsync(parameters);
                return Ok();
            }

            [HttpDelete]
            [Route("Delete")]
            public async Task<IActionResult> Delete(Guid id)
            {
                await _addressService.DeleteAsync(id);
                return Ok();
            }

            [HttpPatch]
            [Route("Update")]
            public async Task<IActionResult> Update(AddressUpdateParameters parameters)
            {
                await _addressService.UpdateAsync(parameters);
                return Ok();
            }
        }
}
