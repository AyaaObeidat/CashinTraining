using BookBorrowingLibrary.Models;
using BookBorrowingLibrary.Services;
using BookBorrowingLibraryDtos.BorrowingBook;
using BookBorrowingLibraryDtos.BorrowingOrReturnBookDtos;
using BookBorrowingLibraryDtos.CustomerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookBorrowingLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly BookService _bookService;

        private readonly IConfiguration _configuration;

        public CustomerController(CustomerService customerService, BookService bookService,IConfiguration configuration)
        {
            _customerService = customerService;
            _bookService = bookService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterParameters parameters)
        {
            await _customerService.RegisterAsync(parameters);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginParameters parameters)
        {
            var selectedUser = await _customerService.LoginAsync(parameters);

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

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                selectedUser
            });
        }

        [HttpPatch]
        [Route("ModifyFullName")]
        [Authorize]
        public async Task<IActionResult> ModifyFullNameAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyFullNameAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPassword")]
        [Authorize]
        public async Task<IActionResult> ModifyPasswordAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyPasswordAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("ModifyPhoneNumber")]
        [Authorize]
        public async Task<IActionResult> ModifyPhoneNumberAsync(CustomerUpdateParameters parameters)
        {
            await _customerService.ModifyPhoneNumberAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllBooks")]
        [Authorize]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _bookService.GetAllBooksAsync()); 
        }

        [HttpPost]
        [Route("Borrow_Book")]
        [Authorize]
        public async Task<IActionResult> Borrow_BookAsync(BorrowOrReturn_BookParameter parameters)
        {
           await _customerService.Borrow_BookAsync(parameters);
           return Ok();
        }


        [HttpPost]
        [Route("ReturnBorrow_sBook")]
        [Authorize]
        public async Task<IActionResult> ReturnBorrow_sBookAsync(CustomerGetByParameter parameter)
        {
            return Ok(await _customerService.ReturnBorrow_sBookAsync(parameter));
        }


        [HttpPost]
        [Route("Return_Book")]
        [Authorize]
        public async Task<IActionResult> Return_BookAsync(BorrowOrReturn_BookParameter parameter)
        {
            await _customerService.Return_BookAsync(parameter);
            return Ok();
        }
    }
}
