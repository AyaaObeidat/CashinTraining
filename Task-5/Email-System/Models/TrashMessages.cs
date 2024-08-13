namespace Email_System.Models
{
    public class TrashMessages : Parent
    {
        public Guid TrashId { get; private set; }
        public Guid MessageId { get; private set; }

        private TrashMessages() { }
        private TrashMessages(Guid trashId, Guid messageId)
        {

            TrashId = trashId;
            MessageId = messageId;
        }
        public static TrashMessages Create(Guid trashId, Guid messageId)
        {
            if (trashId == Guid.Empty || messageId == Guid.Empty) { throw new ArgumentNullException(); }
            return new TrashMessages(trashId, messageId);
        }
    }
}
