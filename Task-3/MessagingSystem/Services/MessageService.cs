using MessagingSystem.Dtos.MessageDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class MessageService
    {

        private readonly IMessageInterface _messageInterface;
        public MessageService(IMessageInterface messageInterface)
        {
            _messageInterface = messageInterface;
        }

        public async Task<List<MessageDetails>> GetAllAsync()
        {
            var messages = await _messageInterface.GetAllAsync();
            return messages.Select(m => new MessageDetails
            {
                Id = m.Id,
                Subject = m.Subject,
                ContentBody = m.ContentBody,
                Distinations = m.Distinations,
                Status = m.Status,
            }).ToList();
        }
        public async Task<MessageDetails> GetByIdAsync(Guid id)
        {
            var message = await _messageInterface.GetByIdAsync(id);
            return new MessageDetails
            {
                Id = message.Id,
                Subject = message.Subject,
                ContentBody = message.ContentBody,
                Distinations = message.Distinations,
                Status = message.Status
            };
        }

        public async Task Create(MessageCreateParameters parameters)
        {
            var message = Message.Create(parameters.Subject , parameters.ContentBody , MessageSendingStatus.Draft);
            await _messageInterface.AddAsync(message);
        }

       

        public async Task DeleteAsync(Guid id)
        {
            var message = await _messageInterface.GetByIdAsync(id);
            await _messageInterface.DeleteAsync(message);
        }


        public async Task UpdateContentBody(MessageUpdateParameters parameters)
        {
            var message = await _messageInterface.GetByIdAsync(parameters.Id);
            if(message.Status == MessageSendingStatus.Draft)
            {
                message.SetContentBody(parameters.ContentBody);
                await _messageInterface.UpdateAsync(message);
            }
           
        }
        public async Task UpdateSubject(MessageUpdateParameters parameters)
        {
            var message = await _messageInterface.GetByIdAsync(parameters.Id);
            if (message.Status == MessageSendingStatus.Draft)
            {
                message.SetSubject(parameters.Subject);
                await _messageInterface.UpdateAsync(message);
            }
               
        }


    }
}
