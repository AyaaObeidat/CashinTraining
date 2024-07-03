using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(UserService userService , IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegister user)
        {
            await _userService.RegisterAsync(user);
            return (Ok());
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogin user)
        {
            var selectedUser = await _userService.LoginAsync(user);

            if(selectedUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
          {
            new Claim(JwtRegisteredClaimNames.Sub, selectedUser.TripleName),
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
            var users = await _userService.GetAllUsersAsync();
            return (Ok(users));
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromBody] UserGetByParameter parameter)
        {
            var user = await _userService.GetByIdAsync(parameter);
            return (Ok(user));
        }

        [HttpPatch]
        [Route("ModifyName")]
        [Authorize]
        public async Task<IActionResult> ModifyNameAsync([FromBody] UserUpdateParameters parameters)
        {
             await _userService.ModifyName(parameters);
            return (Ok());
        }


        [HttpPatch]
        [Route("ModifyPassword")]
        [Authorize]
        public async Task<IActionResult> ModifyPasswordAsync([FromBody] UserUpdateParameters parameters)
        {
            await _userService.ModifyPassword(parameters);
            return (Ok());
        }
    }
}
