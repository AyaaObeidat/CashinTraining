namespace Email_System.Models
{
    public class InboxMessages : Parent
    {
        public Guid InboxId { get;private set; }
        public Guid MessageId { get;private set; }

        private InboxMessages() { }
        private InboxMessages(Guid inboxId, Guid messageId)
        {
            
            InboxId = inboxId;
            MessageId = messageId;
        }
        public static InboxMessages Create(Guid inboxId, Guid messageId)
        {
            if (inboxId == Guid.Empty || messageId == Guid.Empty) { throw new ArgumentNullException(); }
            return new InboxMessages(inboxId, messageId);
        }
    }
}
