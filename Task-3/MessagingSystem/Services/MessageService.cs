using MessagingSystem.Dtos.InboxDtos;
using MessagingSystem.Dtos.MessageDtos;
using MessagingSystem.Models;
using MessagingSystem.Repositories.Interfaces;

namespace MessagingSystem.Services
{
    public class MessageService
    {
        private readonly IMessageInterface _messageInterface;
        private readonly IUserProfileInterface _userProfileInterface;
        public MessageService(IMessageInterface messageInterface, IUserProfileInterface userProfileInterface)
        {
            _messageInterface = messageInterface;
            _userProfileInterface = userProfileInterface;
        }

        public async Task CreateAsync(MessageCreateParameter parameters)
        {
            var sender = await _userProfileInterface.GetByUserEmail(parameters.SenderEmail);
            var recevier = await _userProfileInterface.GetByUserEmail(parameters.RecreceiverEmail);
            if(sender==null || recevier==null) { return; }

            var message = Message.Create(parameters.SenderEmail, parameters.RecreceiverEmail, parameters.Content, sender.InboxId);

             await _messageInterface.AddAsync(message);
        }

        public async Task SendAsync(Guid id)
        {
           Message message = await _messageInterface.GetByIdAsync(id);
           if(message==null) { return; }    

           message.SetStatus1(CreatedMessageStatus.sending);
           message.SetStatus2(mailedMessageStatus.UnRead);
           var recevier = await _userProfileInterface.GetByUserEmail(message.RecreceiverEmail);

            message.SetInboxIId(recevier.InboxId);
            await _messageInterface.UpdateAsync(message);
                
        }

        public async Task ReplayAsync(Guid lastMessageId , Guid currentMessageId)
        {
            var lastMessage = await _messageInterface.GetByIdAsync(lastMessageId);
            var currentMessage = await _messageInterface.GetByIdAsync(currentMessageId);

            lastMessage.SetStatus2(mailedMessageStatus.Read);
            currentMessage.SetStatus1(CreatedMessageStatus.sending);
            currentMessage.SetStatus2(mailedMessageStatus.UnRead);

            var lastMessageSender = await _userProfileInterface.GetByUserEmail(lastMessage.SenderEmail);
            currentMessage.SetInboxIId(lastMessageSender.InboxId);

            await _messageInterface.UpdateAsync(lastMessage);
            await _messageInterface.UpdateAsync(currentMessage);

        }

        public async Task UpdateContentAsync (MessageUpdateParameters parameters)
        {
            var message = await _messageInterface.GetByIdAsync(parameters.id);
            if(message == null) { return; }

            if(message.SenderEmail == parameters.SenderEmail && message.Status1 == CreatedMessageStatus.Unsending)
            {
                message.UpdateContent(parameters.Content);
                await _messageInterface.UpdateAsync(message);
            }
        }


        public async Task DeleteAsync(Guid id)
        {
            var message =await _messageInterface.GetByIdAsync(id);
            if(message == null) { return; }
            if(message.Status1 == CreatedMessageStatus.Unsending || (message.Status1==CreatedMessageStatus.sending && message.Status2==mailedMessageStatus.UnRead ))
            {
                await _messageInterface.DeleteAsync(message);
            }
        }

        public async Task<List<MessageDetails>> GetAllAsync()
        {
            var messages = await _messageInterface.GetAllAsync();
            return messages.Select(i => new MessageDetails
            {
               Id = i.Id,
               SenderEmail = i.SenderEmail,
               RecreceiverEmail = i.RecreceiverEmail,
               Content = i.Content,
               CreatedAt = i.CreatedAt,
               InboxId = i.InboxId,
               Status1 = i.Status1,
               Status2 = i.Status2,
            }).ToList();
        }

        public async Task<MessageDetails> GetByIdAsync(Guid id)
        {
            var message = await _messageInterface.GetByIdAsync(id);
            if (message == null) return null;
            return new MessageDetails
            {
                Id = message.Id,
                SenderEmail = message.SenderEmail,
                RecreceiverEmail = message.RecreceiverEmail,
                Content =   message.Content,
                CreatedAt = message.CreatedAt,
                InboxId = message.InboxId,
                Status1 = message.Status1,
                Status2 = message.Status2,
            };
        }
    }
}
