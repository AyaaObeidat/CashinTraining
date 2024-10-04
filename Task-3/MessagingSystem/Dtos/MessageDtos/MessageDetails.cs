using MessagingSystem.Models;

namespace MessagingSystem.Dtos.MessageDtos
{
    public class MessageDetails
    {
        public Guid Id { get; set; }
        public string Subject { get;  set; }
        public string ContentBody { get;  set; } 
        public List<MessageDistination> Distinations { get;  set; }
        public MessageSendingStatus Status { get;  set; }
    }
}
