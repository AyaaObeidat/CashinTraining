using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ShopDtos;
using Mahali.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] ShopRegister parameters)
        {
            await _shopService.RegisterAsync(parameters);
            return Ok();
        }
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(string userName_Email , string password)
        {
            var shop = await _shopService.LoginAsync(userName_Email, password);
            if (shop == null) { return BadRequest(); }
            return Ok(shop);
        }

        [HttpPatch]
        [Route("ModifyShopName")]
        public async Task<IActionResult> ModifyShopNameAsync(ShopUpdateParameters parameters)
        {
            await _shopService.ModifyShopNameAsync(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyShopPassword")]
        public async Task<IActionResult> ModifyShopPasswordAsync(ShopUpdateParameters parameters)
        {
            await _shopService.ModifyShopPasswordAsync(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyShopPhoneNumber")]
        public async Task<IActionResult> ModifyShopPhoneNumberAsync(ShopUpdateParameters parameters)
        {
            await _shopService.ModifyShopPhoneNumberAsync(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyShopDescription")]
        public async Task<IActionResult> ModifyShopDescriptionAsync(ShopUpdateParameters parameters)
        {
            await _shopService.ModifyShopDescriptionAsync(parameters);
            return Ok();
        }
    }
}
