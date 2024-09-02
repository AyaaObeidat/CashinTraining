using Email_System.Models;
using Email_System.Services;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Email_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        private  IConfiguration _configuration;
        public UserController(UserService userService , IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
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

            var selectedUser = await _userService.LoginAsync(parameter);

            if (selectedUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
          {
            new Claim(JwtRegisteredClaimNames.Sub, selectedUser.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, selectedUser.Id.ToString()),
          };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);

            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
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
        [Authorize]
        public async Task<IActionResult> ModifyFullNameAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyFullNameAsync(parameter);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyPassword")]
        [Authorize]
        public async Task<IActionResult> ModifyPasswordAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyPasswordAsync(parameter);
            return Ok();
        }
        [HttpPatch]
        [Route("ModifyProfileImage")]
        [Authorize]
        public async Task<IActionResult> ModifyProfileImageAsync(UserUpdateParameter parameter)
        {
            await _userService.ModifyProfileImageAsync(parameter);
            return Ok();
        }
    }
}
