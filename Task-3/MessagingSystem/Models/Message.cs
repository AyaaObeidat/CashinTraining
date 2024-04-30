namespace MessagingSystem.Models
{
    public enum CreatedMessageStatus { sending , Unsending }
    public enum mailedMessageStatus { Read, UnRead }
    public class Message
    {
        public Guid Id { get; set; }
        public string SenderEmail { get; private set; } = null!;
        public string RecreceiverEmail { get;private set; } = null!;
        public string Content { get; private set; } = null!;
        public CreatedMessageStatus Status1 { get; private set; }
        public mailedMessageStatus Status2 { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid InboxId { get; private set; }

        public Message() { }
        public Message(string senderEmail, string receiverEmail, string content, Guid inboxId)
        {
            SenderEmail = senderEmail;
            RecreceiverEmail = receiverEmail;
            Content = content;
            InboxId = inboxId;
            Status1 = CreatedMessageStatus.Unsending;
            Status2 = mailedMessageStatus.UnRead;
            CreatedAt = DateTime.Now;
        }
        public static Message Create(string senderEmail, string receiverEmail, string content, Guid inboxId)
        {
            if (string.IsNullOrEmpty(senderEmail)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(receiverEmail)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(content)) { throw new ArgumentNullException(); }
            return new Message(senderEmail, receiverEmail, content, inboxId);
        }

        public void SetStatus1( CreatedMessageStatus status ) { Status1 = status; }
        public void SetStatus2(mailedMessageStatus status) { Status2 = status; }
        public void SetInboxIId (Guid id) { InboxId = id; }
        public void UpdateContent(string content) { Content = content; }
    }
}
