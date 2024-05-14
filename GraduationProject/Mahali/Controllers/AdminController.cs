using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ReportDtos;
using Mahali.Dtos.ShopRecuestDtos;
using Mahali.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mahali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AdminRegister parameters)
        {
            var admin = await _adminService.RegisterAsync(parameters);
            if(admin == null) { BadRequest(); }
            return Ok(admin);
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(AdminLogin adminLogin)
        {
            var admin = await _adminService.LoginAsync(adminLogin);
            if (admin == null) { BadRequest(); }
            return Ok(admin);
        }
        
        [HttpPatch]
        [Route("ModifyAccountUserName")]
        public async Task<IActionResult> ModifyAccountUserNameAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyAccountUserNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyAccountPassword")]
        public async Task<IActionResult> ModifyAccountPasswordAsync(AdminUpdateParameters parameters)
        {
            await _adminService.ModifyAccountPasswordAsync(parameters);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllShops")]
        public async Task<IActionResult> GetAllShopsAsync()
        {
            return Ok(await _adminService.GetAllShopRequestAsync());
        }

        [HttpPatch]
        [Route("UpdateShopRequestStatus")]
        public async Task<IActionResult> UpdateShopRequestStatus(ShopRequestUpdateParameters parameters)
        {
            await _adminService.UpdateShopRequestStatusAsync(parameters);
            return Ok();
        }
    }
}
