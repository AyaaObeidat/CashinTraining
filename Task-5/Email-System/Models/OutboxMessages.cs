namespace Email_System.Models
{
    public class OutboxMessages : Parent
    {
        public Guid OutboxId { get; private set; }
        public Guid MessageId { get; private set; }

        private OutboxMessages() { }
        private OutboxMessages(Guid outboxId, Guid messageId)
        {
            OutboxId = outboxId;
            MessageId = messageId;
        }
        public static OutboxMessages Create(Guid outboxId, Guid messageId)
        {
            if (outboxId == Guid.Empty || messageId == Guid.Empty) { throw new ArgumentNullException(); }
            return new OutboxMessages(outboxId, messageId);
        }
    }
}
