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
               UserId = u.UserId,
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
                UserId = messageDistination.UserId,
                MessageId = messageDistination.MessageId,
                Box = messageDistination.Box,
                Read = messageDistination.Read
            };
        }

        public async Task SendMessage(MessageDistinationCreateParameters parameters)
        {
            var message = await _messageInterface.GetByIdAsync(parameters.MessageId);
            var messageDistination = MessageDistination.Create(parameters.UserId , parameters.MessageId , parameters.Box);
            message.SetMessageSendingStatus(MessageSendingStatus.Sent);
            await _messageInterface.UpdateAsync(message);
            await _messageDistinationInterface.AddAsync(messageDistination);
        }

        public async Task TrashMessageAsync(Guid userId, Guid messageId)
        {

            var user = await _userInterface.GetByIdAsync(userId);
            var trashMessage = user.Messages.FirstOrDefault(m => m.MessageId==messageId);
            trashMessage.SetBox(MessageBox.TrashBox);
            await _messageDistinationInterface.UpdateAsync(trashMessage);

            
        }
        public async Task<List<MessageDistination>> GetAllTrashMessagesAsync(Guid userId)
        {

            var user = await _userInterface.GetByIdAsync(userId);
            var trashMessages = user.Messages.Where(m => m.Box==MessageBox.TrashBox).ToList();
            return trashMessages;
        }
        public async Task<List<MessageDistination>> GetAllInboxMessagesAsync(Guid userId)
        {

            var user = await _userInterface.GetByIdAsync(userId);
            var trashMessages = user.Messages.Where(m => m.Box == MessageBox.Inbox).ToList();
            return trashMessages;
        }
        public async Task<List<MessageDistination>> GetAllOutboxMessagesAsync(Guid userId)
        {

            var user = await _userInterface.GetByIdAsync(userId);
            var trashMessages = user.Messages.Where(m => m.Box == MessageBox.OutBox).ToList();
            return trashMessages;
        }

    }
}
