using Mahali.Dtos.AdminDtos;
using Mahali.Dtos.ReportDtos;
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
        public async Task<IActionResult> LoginAsync(string userName_Email , string password)
        {
            var admin = await _adminService.LoginAsync(userName_Email , password);
            if (admin == null) { BadRequest(); }
            return Ok(admin);
        }

        [HttpGet]
        [Route("GetAllShops")]
        public async Task<IActionResult> GetAllShopsAsync()
        {
            return Ok(await _adminService.GetAllShopRequestAsync());
        }

        [HttpGet]
        [Route("GetReports")]
        public async Task<IActionResult> GetAllReportsAsync()
        {
            return Ok(await _adminService.GetAllReportsAsync());
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


        [HttpPost]
        [Route("WriteReport")]
        public async Task<IActionResult> WriteReportAsync(ReportCreateParameters parameters)
        {
            await _adminService.WriteReportAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("EditReportText")]
        public async Task<IActionResult> EditReportTextAsync(ReportUpdateParameters parameters)
        {
            await _adminService.EditReportTextAsync(parameters);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteReport")]
        public async Task<IActionResult> DeleteReportAsync(string shopName)
        {
            await _adminService.DeleteReportAsync(shopName);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateShopRequestStatus")]
        public async Task<IActionResult> UpdateShopRequestStatus(string shopName , RequestStatus status)
        {
            await _adminService.UpdateShopRequestStatusAsync(shopName, status);
            return Ok();
        }
    }
}
