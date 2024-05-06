using MessagingSystem.Models;

namespace MessagingSystem.Dtos.MessageDtos
{
    public class MessageCreateParameters
    {
        public string Subject { get; set; }
        public string ContentBody { get; set; }
        public MessageSendingStatus Status { get; set; }
    }
}
