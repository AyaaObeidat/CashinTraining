namespace Email_System.Models
{
    public class Inbox  : Parent
    {
        public Guid UserId { get;private set; }
        public List<InboxMessages>? Messages { get; set; }
        
        private Inbox() { }
        private Inbox(Guid userId)
        {
            UserId = userId;
        }
        public static Inbox Create(Guid userId)
        {
            if (userId == Guid.Empty) { throw new ArgumentNullException(); }
            return new Inbox(userId);
        }
        public void SetMessages(List<InboxMessages>? messages)
        {
            if (messages == null) { throw new ArgumentNullException(); }
            Messages = messages;
        }
        

    }
}
