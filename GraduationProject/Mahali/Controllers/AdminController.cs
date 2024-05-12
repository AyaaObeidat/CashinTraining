using Mahali.Dtos.AdminDtos;
using Mahali.Services;
using Microsoft.AspNetCore.Http;
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
    }
}
