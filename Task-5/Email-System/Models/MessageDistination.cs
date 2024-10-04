namespace Email_System.Models
{
    public class MessageDestination : Parent
    {
        
        public Guid MessageId { get;private set; }
        public Guid UserId { get;private set; }

        private MessageDestination() { }
        private MessageDestination(Guid messageId, Guid userId)
        {
            MessageId = messageId;
            UserId = userId;
        }

        public static MessageDestination Create(Guid messageId, Guid userId)
        {
            if (messageId == Guid.Empty || userId == Guid.Empty) { throw new ArgumentNullException(); }
            return new MessageDestination(messageId, userId);
        }
    }
}
