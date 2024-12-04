using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profolio.Services;
using ProfolioDtos.UserDtos;

namespace Profolio.Controllers
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
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterParameters parameters)
        {
            await _userService.RegisterAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginParameters parameters)
        {
            return Ok(await _userService.LoginAsync(parameters));
        }

        [HttpGet]
        [Route("GetAllPublicUsers")]
        public async Task<IActionResult> GetAllPublicUsersAsync()
        {
            return Ok(await _userService.GetAllPublicUsersAsync());
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromBody] UserGetByParameters parameters)
        {
            return Ok(await _userService.GetByIdAsync(parameters));
        }

        [HttpPatch]
        [Route("ModifyFullName")]
        public async Task<IActionResult> ModifyFullNameAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyFullNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPassword")]
        public async Task<IActionResult> ModifyPasswordAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyPasswordAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPhoneNumber")]
        public async Task<IActionResult> ModifyPhoneNumberAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyPhoneNumberAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyAbout")]
        public async Task<IActionResult> ModifyAboutAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyAboutAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyEducation")]
        public async Task<IActionResult> ModifyEducationAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyEducationAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyJobTitle")]
        public async Task<IActionResult> ModifyJobTitleAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyJobTitleAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyImageUrl")]
        public async Task<IActionResult> ModifyImageUrlAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyImageUrlAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyCvUrl")]
        public async Task<IActionResult> ModifyCvUrlAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyCVUrlAsync(parameters);
            return Ok();
        }
    }
}
