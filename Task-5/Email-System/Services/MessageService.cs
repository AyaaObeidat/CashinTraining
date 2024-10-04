using Email_System.Models;
using Email_System.Repositories.Interfaces;
using EmailSystemDtos.MessageDestinationDtos;
using EmailSystemDtos.MessageDistinanationDtos;
using EmailSystemDtos.MessageDtos;
using EmailSystemDtos.TrashMessagesDtos;
using EmailSystemDtos.UserDtos;
using EmailSystemEnums;

namespace Email_System.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageDestinationRepository _messageDestinationRepository;
        private readonly IInboxMessagesRepository _inboxMessagesRepository;
        private readonly IOutboxMessagesRepository _outboxMessagesRepository;
        private readonly ITrashMessagesRepository _trashMessagesRepository;
        private readonly ITrashRepository _trashRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IMessageDestinationRepository messageDestinationRepository,
            IInboxMessagesRepository inboxMessagesRepository, IOutboxMessagesRepository outboxMessagesRepository, ITrashMessagesRepository trashMessagesRepository,
            ITrashRepository trashRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _messageDestinationRepository = messageDestinationRepository;
            _inboxMessagesRepository = inboxMessagesRepository;
            _outboxMessagesRepository = outboxMessagesRepository;
            _trashMessagesRepository = trashMessagesRepository;
            _trashRepository = trashRepository;
        }

        public async Task CreateMessageAsync(MessageCreateParameter parameters)
        {
            var sender = await _userRepository.GetByIdAsync(parameters.SenderId);
            if (sender == null) return;

            var message = Message.Create(parameters.SenderId, parameters.Subject, parameters.ContentBody);
            await _messageRepository.AddAsync(message);
            message.SetCreatedDate();
            await _messageRepository.UpdateAsync(message);

        }

        public async Task SentMessageAsync(MessageDestinationCreateParameter parameters)
        {
            var message = await _messageRepository.GetByIdAsync(parameters.MessageId);
            var receiver = await _userRepository.GetByIdAsync(parameters.ReceiverId);
            if (message == null || receiver == null) return;
            var sender = await _userRepository.GetByIdAsync(message.SenderId);

            var messageDis = MessageDestination.Create(parameters.MessageId, parameters.ReceiverId);
            await _messageDestinationRepository.AddAsync(messageDis);
            messageDis.SetCreatedDate();
            await _messageDestinationRepository.UpdateAsync(messageDis);

            message.SetMessageStatus();
            message.SetSentDate();
            await _messageRepository.UpdateAsync(message);

            //inbox ==> receiver
            var inboxMessage = InboxMessages.Create(receiver.InboxId, message.Id);
            await _inboxMessagesRepository.AddAsync(inboxMessage);
            inboxMessage.SetCreatedDate();
            await _inboxMessagesRepository.UpdateAsync(inboxMessage);

            //outbox ==> sender
            var outboxMessage = OutboxMessages.Create(sender.OutboxId, message.Id);
            await _outboxMessagesRepository.AddAsync(outboxMessage);
            outboxMessage.SetCreatedDate();
            await _outboxMessagesRepository.UpdateAsync(outboxMessage);

        }

        public async Task MoveMessageToTrashAsync(TrashMessageCreateParameters parameter)
        {
            var message = await _messageRepository.GetByIdAsync(parameter.MessageId);
            var trash = await _trashRepository.GetByIdAsync(parameter.TrashId);
            var user = await _userRepository.GetByIdAsync(trash.UserId);

            if (message == null || trash == null || user == null) { return; }

            var trashMessage = TrashMessages.Create(parameter.TrashId, parameter.MessageId);
            await _trashMessagesRepository.AddAsync(trashMessage);
            trashMessage.SetCreatedDate();
            await _trashMessagesRepository.UpdateAsync(trashMessage);

            var inboxMessages = await _inboxMessagesRepository.GetAllAsync();
            foreach (var inboxMessage in inboxMessages)
            {
                if (inboxMessage.MessageId == parameter.MessageId && inboxMessage.InboxId == user.InboxId)
                {
                    await _inboxMessagesRepository.DeleteAsync(inboxMessage.Id);
                }

            }

            var outboxMessages = await _outboxMessagesRepository.GetAllAsync();
            foreach (var outboxMessage in outboxMessages)
            {
                if (outboxMessage.MessageId == parameter.MessageId && outboxMessage.OutboxId == user.OutboxId)
                {
                    await _outboxMessagesRepository.DeleteAsync(outboxMessage.Id);
                }

            }

        }

        public async Task<MessageDetails?> GetMessageByIdAsync(MessageGetByParameter parameter)
        {
            var message = await _messageRepository.GetByIdAsync(parameter.Id);
            if (message == null) { return null; }
            return new MessageDetails
            {
                SenderId = message.SenderId,
                Subject = message.Subject,
                ContentBody = message.ContentBody,
                SentDate = message.SentDate,
                Status = message.Status,
            };
        }

        public async Task EditMessageSubjectAsync(MessageUpdateParameter parameter)
        {
            var message = await _messageRepository.GetByIdAsync(parameter.MessageId);
            if (message == null) { return; }

            if (IsDraft(message))
            {
                message.SetSubject(parameter.Subject);
                await _messageRepository.UpdateAsync(message);
            }
           
        }


        public async Task EditMessageContentBodyAsync(MessageUpdateParameter parameter)
        {
            var message = await _messageRepository.GetByIdAsync(parameter.MessageId);
            if (message == null) { return; }
            if (IsDraft(message))
            {
                message.SetContentBody(parameter.ContentBody);
                await _messageRepository.UpdateAsync(message);
            }
        }


        //BV
        public  bool IsDraft(Message message)
        {
            return message.Status == MessageStatus.Draft;
        }

    }
}
