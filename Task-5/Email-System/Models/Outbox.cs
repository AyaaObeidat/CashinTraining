namespace Email_System.Models
{
    public class Outbox : Parent
    {
        
        public Guid UserId { get; private set; }
        public List<OutboxMessages>? Messages { get; set; }
        private Outbox() { }
        private Outbox(Guid userId)
        {
            UserId = userId;
        }
        public static Outbox Create(Guid userId)
        {
            if (userId == Guid.Empty) { throw new ArgumentNullException(); }
            return new Outbox(userId);
        }
       
        public void SetMessages(List<OutboxMessages>? messages)
        {
            if (messages == null) { throw new ArgumentNullException(); }
            Messages = messages;
        }
    }
}
