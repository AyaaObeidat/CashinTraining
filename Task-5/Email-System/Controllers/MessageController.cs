using Email_System.Services;
using EmailSystemDtos.MessageDestinationDtos;
using EmailSystemDtos.MessageDtos;
using EmailSystemDtos.TrashMessagesDtos;
using EmailSystemDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> CreateMessageAsync(MessageCreateParameter parameter)
        {
            await _messageService.CreateMessageAsync(parameter);
            return Ok();
        }

        [HttpPost]
        [Route("Sent")]
        [Authorize]
        public async Task<IActionResult> SentMessageAsync(MessageDestinationCreateParameter parameter)
        {
            await _messageService.SentMessageAsync(parameter);
            return Ok();
        }

        [HttpDelete]
        [Route("MoveMessageToTrash")]
        [Authorize]
        public async Task<IActionResult> MoveMessageToTrashAsync(TrashMessageCreateParameters parameter)
        {
            await _messageService.MoveMessageToTrashAsync(parameter);
            return Ok();
        }

        [HttpPost]
        [Route("GetById")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(MessageGetByParameter parameter)
        {
            await _messageService.GetMessageByIdAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("EditMessageContentBody")]
        [Authorize]
        public async Task<IActionResult> EditMessageContentBodyAsync(MessageUpdateParameter parameter)
        {
            await _messageService.EditMessageContentBodyAsync(parameter);
            return Ok();
        }

        [HttpPatch]
        [Route("EditMessageSubject")]
        [Authorize]
        public async Task<IActionResult> EditMessageSubjectAsync(MessageUpdateParameter parameter)
        {
            await _messageService.EditMessageSubjectAsync(parameter);
            return Ok();
        }

    }
}
