namespace Email_System.Models
{
    public class Trash : Parent
    {
        public Guid UserId { get; private set; }
        public List<TrashMessages>? Messages { get; set; }
        private Trash() { }
        private Trash(Guid userId)
        {
            UserId = userId;
        }
        public static Trash Create(Guid userId)
        {
            if (userId == Guid.Empty) { throw new ArgumentNullException(); }
            return new Trash(userId);
        }
        public void SetMessages(List<TrashMessages>? messages)
        {
            if (messages == null) { throw new ArgumentNullException(); }
            Messages = messages;
        }

    }
}
