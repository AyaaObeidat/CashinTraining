namespace MessagingSystem.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Subject { get; private set; } = null!;
        public string ContentBody { get; private set; } = null!;
        public List<MessageDistination> Distinations { get; private set; }
        public MessageSendingStatus Status { get; private set; }

        private Message()
        {

        }
        private Message(string subject, string contentBody, MessageSendingStatus status)
        {
            Subject = subject;
            ContentBody = contentBody;
            Status = status;
        }

        public static Message Create(string subject, string contentBody, MessageSendingStatus status)
        {
            if (string.IsNullOrEmpty(subject)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(contentBody)) { throw new ArgumentNullException(); }
            return new Message(subject, contentBody, status);
        }
    }
}
