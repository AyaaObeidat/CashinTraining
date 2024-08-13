using Email_System.Services;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(UserCreateParameter parameter)
        {
            await _userService.RegisterAsync(parameter);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginParameter parameter)
        {
            
            return Ok(await _userService.LoginAsync(parameter));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {

            return Ok(await _userService.GetAllAsync());
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(UserGetByParameter parameter)
        {

            return Ok(await _userService.GetByIdAsync(parameter));
        }

        [HttpPatch]
        [Route("ModifyFullName")]
        public async Task<IActionResult> ModifyFullNameAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyFullNameAsync(parameter);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyPassword")]
        public async Task<IActionResult> ModifyPasswordAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyPasswordAsync(parameter);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyProfileImage")]
        public async Task<IActionResult> ModifyProfileImageAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyProfileImageAsync(parameter);
            return Ok();
        }
    }
}
