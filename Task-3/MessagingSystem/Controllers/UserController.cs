using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingSystem.Controllers
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
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody] UserCreateParameters parameters) 
        {
            await _userService.AddAsync(parameters);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
           return Ok(await _userService.GetAllAsync());
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
