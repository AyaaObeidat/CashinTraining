using Email_System.Services;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly UserMessagesService _userMessagesService;

        public UserMessagesController(UserMessagesService userMessagesService)
        {
            _userMessagesService = userMessagesService;
        }

        [HttpPost]
        [Route("UserDraftMessages")]
        [Authorize]
        public async Task<IActionResult> UserDraftMessagesAsync(UserGetByParameter parameter)
        {
            return Ok(await _userMessagesService.UserDraftMessagesAsync(parameter));
        }

        [HttpPost]
        [Route("UserInboxMessages")]
        [Authorize]
        public async Task<IActionResult> UserInboxMessagesAsync(UserGetByParameter parameter)
        {
            return Ok(await _userMessagesService.UserInboxMessagesAsync(parameter));
        }

        [HttpPost]
        [Route("UserOutboxMessages")]
        [Authorize]
        public async Task<IActionResult> UserOutboxMessagesAsync(UserGetByParameter parameter)
        {
            return Ok(await _userMessagesService.UserOutboxMessagesAsync(parameter));
        }

        [HttpPost]
        [Route("UserTrashMessages")]
        [Authorize]
        public async Task<IActionResult> UserTrashMessagesAsync(UserGetByParameter parameter)
        {
            return Ok(await _userMessagesService.UserTrashMessagesAsync(parameter));
        }
    }
}
