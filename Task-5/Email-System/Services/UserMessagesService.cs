using Email_System.Models;
using Email_System.Repositories.Interfaces;
using EmailSystemDtos.MessageDistinanationDtos;
using EmailSystemDtos.MessageDtos;
using EmailSystemDtos.UserDtos;
using EmailSystemEnums;

namespace Email_System.Services
{
    public class UserMessagesService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IInboxRepository _inboxRepository;
        private readonly IOutboxRepository _outboxRepository;
        private readonly ITrashRepository _trashRepository;
        private readonly IMessageDestinationRepository _destinationRepository;

        public UserMessagesService(IUserRepository userRepository,IMessageRepository messageRepository,IInboxRepository inboxRepository,IOutboxRepository outboxRepository,
            IMessageDestinationRepository messageDestinationRepository,ITrashRepository trashRepository)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _inboxRepository = inboxRepository;
            _outboxRepository = outboxRepository;
            _destinationRepository = messageDestinationRepository;
            _trashRepository = trashRepository;
        }

        public async Task<List<MessageDetails>?> UserDraftMessagesAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) return null;

            var messages = await _messageRepository.GetAllAsync();

            var draftMessages = new List<Message>();
            foreach (var message in messages.ToList())
            {
                if(message.SenderId == user.Id)
                {
                    var m = await _messageRepository.GetByIdAsync(message.Id);
                    if (m.Status == MessageStatus.Draft)
                    {
                        draftMessages.Add(m);
                    }
                }
               
            }

            return draftMessages.Select(x => new MessageDetails
            {
               Id = x.Id,
               SenderId = x.SenderId,
               Subject = x.Subject,
               ContentBody = x.ContentBody,
               CreatedDate = x.CreatedDate,
            }).ToList();
        }

        public async Task<List<MessageDetails>?> UserInboxMessagesAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) return null;

            var inboxes = await _inboxRepository.GetAllAsync();
            var userInbox = inboxes.FirstOrDefault(x => x.UserId == parameter.Id);
            var userInboxMessages = new List<Message>();

            foreach (var message in userInbox.Messages.ToList())
            {
                var m = await _messageRepository.GetByIdAsync(message.MessageId);
                userInboxMessages.Add(m);
            }

            return userInboxMessages.Select(x => new MessageDetails
            {
                Id = x.Id,
                SenderId = x.SenderId,
                Subject = x.Subject,
                ContentBody = x.ContentBody,
                CreatedDate = x.CreatedDate,
            }).ToList();

        }

        public async Task<List<MessageDestinationDetails>?> UserOutboxMessagesAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) return null;

            var outboxes = await _outboxRepository.GetAllAsync();
            var userOutbox = outboxes.FirstOrDefault(x => x.UserId == parameter.Id);
            var messageDestinations = await _destinationRepository.GetAllAsync();

            var userOutboxMessages = new List<MessageDestinationDetails>();

            foreach (var message in userOutbox.Messages.ToList())
            {
                var m = await _messageRepository.GetByIdAsync(message.MessageId);
                var mds = messageDestinations.Where(x => x.MessageId == message.MessageId).ToList();
                userOutboxMessages.AddRange(mds.Select(x => new MessageDestinationDetails
                {
                    MessageId = x.MessageId,
                    ReceiverId = x.UserId,
                }));
            }

            return userOutboxMessages.Select(x => new MessageDestinationDetails
            {
               MessageId = x.MessageId,
               ReceiverId = x.ReceiverId,
            }).ToList();

        }

        public async Task<List<MessageDetails>?> UserTrashMessagesAsync(UserGetByParameter parameter)
        {
            var user = await _userRepository.GetByIdAsync(parameter.Id);
            if (user == null) return null;

            var trashes = await _trashRepository.GetAllAsync();
            var userTrash = trashes.FirstOrDefault(x => x.UserId == parameter.Id);

            var messages = userTrash.Messages.ToList();
            var trashMessages = new List<Message>();
            foreach (var message in messages)
            {
                var m = await _messageRepository.GetByIdAsync(message.MessageId);
                trashMessages.Add(m);
            }

            return trashMessages.Select(x => new MessageDetails
            {
                Id = x.Id,
                SenderId = x.SenderId,
                Subject = x.Subject,
                ContentBody = x.ContentBody,
                CreatedDate = x.CreatedDate,
            }).ToList();
        }


    }
}
