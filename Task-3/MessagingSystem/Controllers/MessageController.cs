using MessagingSystem.Dtos.MessageDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _messageService.GetAllAsync());
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _messageService.GetByIdAsync(id));
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(MessageCreateParameters parameters)
        {
            await _messageService.Create(parameters);
            return Ok();
        }
       
        [HttpPatch]
        [Route("UpdateContentBody")]
        public async Task<IActionResult> UpdateContentBody(MessageUpdateParameters parameters)
        {
            await _messageService.UpdateContentBody(parameters);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(MessageUpdateParameters parameters)
        {
            await _messageService.UpdateSubject(parameters);
            return Ok();
        }
    }
}
