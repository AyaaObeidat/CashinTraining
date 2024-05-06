using MessagingSystem.Dtos.MessageDistenationDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageDistinationController : ControllerBase
    {
        private readonly MessageDistinationService _messageDistinationService;

        public MessageDistinationController(MessageDistinationService messageDistinationService)
        {
            _messageDistinationService = messageDistinationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _messageDistinationService.GetAllAsync());
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _messageDistinationService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody] MessageDistinationCreateParameters parameters)
        {
            await _messageDistinationService.SendMessage(parameters);
            return Ok();
        }

        [HttpPatch]
        [Route("TrashMessage")]
        public async Task<IActionResult> TrashMessageAsync(Guid userId , Guid messageId)
        {
            await _messageDistinationService.TrashMessageAsync(userId,messageId);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllTrashMessages")]
        public async Task<IActionResult> GetAllTrashMessagesAsync(Guid userId)
        {
            return Ok(await _messageDistinationService.GetAllTrashMessagesAsync(userId));
           
        }
        [HttpGet]
        [Route("GetAllInboxMessages")]
        public async Task<IActionResult> GetAllInboxMessagesAsync(Guid userId)
        {
            return Ok(await _messageDistinationService.GetAllInboxMessagesAsync(userId));

        }
        [HttpGet]
        [Route("GetAllOutboxMessages")]
        public async Task<IActionResult> GetAllOutboxMessagesAsync(Guid userId)
        {
            return Ok(await _messageDistinationService.GetAllOutboxMessagesAsync(userId));

        }
    }
}
