using Email_System.Services;
using EmailSystemDtos.MessageDestinationDtos;
using EmailSystemDtos.MessageDtos;
using EmailSystemDtos.TrashMessagesDtos;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_System.Controllers
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

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateMessageAsync(MessageCreateParameter parameter)
        {
            await _messageService.CreateMessageAsync(parameter);
            return Ok();
        }

        [HttpPost]
        [Route("Sent")]
        public async Task<IActionResult> SentMessageAsync(MessageDestinationCreateParameter parameter)
        {
            await _messageService.SentMessageAsync(parameter);
            return Ok();
        }

        [HttpDelete]
        [Route("MoveMessageToTrash")]
        public async Task<IActionResult> MoveMessageToTrashAsync(TrashMessageCreateParameters parameter)
        {
            await _messageService.MoveMessageToTrash(parameter);
            return Ok();
        }

      

    }
}
