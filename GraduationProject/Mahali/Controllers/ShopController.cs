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

        [HttpGet]
        [Route("GetAllShopOrders")]
        public async Task<IActionResult> GetAllShopOrdersAsync(string shopName)
        {
            var orders = await _shopService.GetAllShopOrdersAsync(shopName);
            if (orders == null) { return BadRequest(); }
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetAllShopProducts")]
        public async Task<IActionResult> GetAllShopProductsAsync(string shopName)
        {
            var products = await _shopService.GetAllShopProductsAsync(shopName);
            if (products == null) { return BadRequest(); }
            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllReviewsList")]
        public async Task<IActionResult> GetAllReviewsListAsync(string shopName)
        {
            var reviews = await _shopService.GetAllReviewsListAsync(shopName);
            if (reviews == null) { return BadRequest(); }
            return Ok(reviews);
        }
    }
}
