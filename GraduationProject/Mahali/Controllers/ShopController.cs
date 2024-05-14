using Mahali.Dtos.ShopDtos;
using Mahali.Services;
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
        public async Task<IActionResult> LoginAsync(ShopLogin login)
        {
            var shop = await _shopService.LoginAsync( login);
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

        [HttpGet]
        [Route("GetAllShopOrders")]
        public async Task<IActionResult> GetShopOrdersAsync(ShopGetByParameter parameter)
        {
            var orders = await _shopService.GetShopOrdersAsync(parameter);
            if (orders == null) { return BadRequest(); }
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetAllShopProducts")]
        public async Task<IActionResult> GetShopProductsAsync(ShopGetByParameter parameter)
        {
            var products = await _shopService.GetShopProductsAsync(parameter);
            if (products == null) { return BadRequest(); }
            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllReviewsList")]
        public async Task<IActionResult> GetReviewsListAsync(ShopGetByParameter parameter)
        {
            var reviews = await _shopService.GetReviewsListAsync(parameter);
            if (reviews == null) { return BadRequest(); }
            return Ok(reviews);
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _shopService.GetAllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(ShopGetByParameter parameter)
        {
            return Ok(await _shopService.GetByIdAsync(parameter));
        }
    }
}