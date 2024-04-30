namespace Messaging_System.Models
{
    public enum MessageStatus { Read , UnRead , Archived}
    public class Message
    {
        public Guid Id { get; set; }
        public Guid SenderId { get;private set; }
        public Guid RecreceiverId { get;private set; }
        public string Content { get; private set; } = null!;
        public MessageStatus Status { get; private set;}
        public DateTime CreatedAt { get; private set; }
        public Guid InboxId { get; private set; }

        public Message () { }
        public Message (Guid senderId , Guid receiverId , string content , Guid inboxId)
        {
            SenderId = senderId;
            RecreceiverId = receiverId;
            Content = content;
            InboxId = inboxId;
            Status = MessageStatus.UnRead;
            CreatedAt = DateTime.Now;
        }
        public static Message Create(Guid senderId, Guid receiverId, string content, Guid inboxId)
        {
            if (string.IsNullOrEmpty(content)) { throw new ArgumentNullException(); }
            return new Message(senderId, receiverId, content, inboxId);
        }
    }
}
