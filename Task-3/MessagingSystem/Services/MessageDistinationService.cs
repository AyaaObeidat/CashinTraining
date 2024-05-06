using MessagingSystem.Dtos.MessageDistenationDtos;
using MessagingSystem.Dtos.UserDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class MessageDistinationService
    {

        private readonly IMessageDistinationInterface _messageDistinationInterface;
        private readonly IUserInterface _userInterface;
        private readonly IMessageInterface _messageInterface;
        public MessageDistinationService(IMessageDistinationInterface messageDistination , IUserInterface userInterface , IMessageInterface messageInterface)

        {
            _messageDistinationInterface = messageDistination;
            _userInterface = userInterface;
            _messageInterface = messageInterface;
        }

        public async Task<List<MessageDistinationDetails>> GetAllAsync()
        {
            var messageDistinations = await _messageDistinationInterface.GetAllAsync();
            return messageDistinations.Select(u => new MessageDistinationDetails
            {
               Id = u.Id,
               SenderId = u.SenderId,
               RecevierId = u.RecevierId,
               MessageId = u.MessageId,
               Box = u.Box,
               Read = u.Read

            }).ToList();
        }
        public async Task<MessageDistinationDetails> GetByIdAsync(Guid id)
        {
            var messageDistination = await _messageDistinationInterface.GetByIdAsync(id);
            return new MessageDistinationDetails
            {
                Id = messageDistination.Id,
                SenderId = messageDistination.SenderId,
                RecevierId = messageDistination.RecevierId,
                MessageId = messageDistination.MessageId,
                Box = messageDistination.Box,
                Read = messageDistination.Read
            };
        }

        public async Task SendMessage(MessageDistinationCreateParameters parameters)
        {
      
            var messageDistination = MessageDistination.Create(parameters.SenderId , parameters.RecevierId , parameters.MessageId );

            await _messageDistinationInterface.AddAsync(messageDistination);
        }
    }
}
