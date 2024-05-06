namespace MessagingSystem.Models
{
    public class MessageDistination
    {
        public Guid Id { get; set; }
        public bool Read { get; private set; }
        public MessageBox Box { get; private set; }
        public User User { get; private set; }
        public Message Message { get; private set; }

        private MessageDistination() { }

        private MessageDistination(User user, Message message, MessageBox box, bool read)
        {
            User = user;
            Message = message;
            Box = box;
            Read = read;
        }

        public static MessageDistination Create(User user, Message message, MessageBox box, bool read)
        {
            return new MessageDistination(user, message, box, read);
        }
    }
}

