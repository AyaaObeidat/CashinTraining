namespace MessagingSystem.Models
{
    public class Inbox
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; private set; }
        public List<Message> Messages { get; private set; } = null!;

        public Inbox() { }
        public Inbox(Guid userProfileId)
        {
            UserProfileId = userProfileId;
        }

        public static Inbox Create(Guid userProfileId)
        {
            return new Inbox(userProfileId);
        }
    }
}
