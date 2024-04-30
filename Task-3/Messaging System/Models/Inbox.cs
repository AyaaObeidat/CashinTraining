namespace Messaging_System.Models
{
    public class Inbox
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get;private set;}
        public List<Message> Messages { get;private set; }

        public Inbox() { }
        public  Inbox(Guid userProfileId )
        {
            UserProfileId = userProfileId;
        }

        public static Inbox Create( Guid userProfileId )
        {
            return new Inbox( userProfileId );
        }
    }
}
