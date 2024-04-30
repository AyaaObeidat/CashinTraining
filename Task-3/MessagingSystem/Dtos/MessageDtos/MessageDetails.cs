using MessagingSystem.Models;

namespace MessagingSystem.Dtos.MessageDtos
{
    public class MessageDetails
    {
        public Guid Id { get; set; }
        public string SenderEmail { get; set; } 
        public string RecreceiverEmail { get; set; } 
        public string Content { get;  set; }
        public CreatedMessageStatus Status1 { get;  set; }
        public mailedMessageStatus Status2 { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public Guid InboxId { get;  set; }

    }
}
