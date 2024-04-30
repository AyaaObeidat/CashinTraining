using MessagingSystem.Dtos.InboxDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        private readonly InboxService  _inboxService;

        public InboxController (InboxService inboxService)
        {
            _inboxService = inboxService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var inboxes = await _inboxService.GetAllAsync();
            return Ok(inboxes);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var inbox = await _inboxService.GetByIdAsync(id);
            if (inbox == null) { return NotFound(); }
            return Ok(inbox);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] InboxCreateParameters parameters)
        {
            await _inboxService.AddAsync(parameters);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _inboxService.DeleteAsync(id);
            return Ok();
        }
    }
}
