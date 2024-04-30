using MessagingSystem.Dtos.MessageDtos;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace MessagingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;
        public MessageController (MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateAsync(MessageCreateParameter parameter)
        {
            await _messageService.CreateAsync(parameter);
            return Ok();
        }


        [HttpPatch]
        [Route("Send")]

        public async Task<IActionResult> SendAsync(Guid id)
        {
            await _messageService.SendAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("Replay")]

        public async Task<IActionResult> ReplayAsync(Guid lastMessageId , Guid currentMessageId)
        {
            await _messageService.ReplayAsync(lastMessageId , currentMessageId);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateContent")]

        public async Task<IActionResult> UpdateAsync(MessageUpdateParameters parameters)
        {
            await _messageService.UpdateContentAsync(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("Delete")]

        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
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

    }
}
