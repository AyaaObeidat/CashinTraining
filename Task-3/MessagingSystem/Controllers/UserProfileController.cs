using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Dtos.UserProfileDtos;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;

        public UserProfileController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _userProfileService.GetAllAsync();
            return Ok(profiles);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var profile = await _userProfileService.GetByIdAsync(id);
            if (profile == null) { return NotFound(); }
            return Ok(profile);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody]UserProfileCreateParameters parameters)
        {
            await _userProfileService.AddAsync(parameters);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userProfileService.DeleteAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateName")]
        public async Task<IActionResult> UpdateName(UserProfileUpdateParameters parameters)
        {
            await _userProfileService.UpdateFullNameAsync(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(UserProfileUpdateParameters parameters)
        {
            await _userProfileService.UpdateFullNameAsync(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateBio")]
        public async Task<IActionResult> UpdateBio(UserProfileUpdateParameters parameters)
        {
            await _userProfileService.UpdateFullNameAsync(parameters);
            return Ok();
        }
    }
}
