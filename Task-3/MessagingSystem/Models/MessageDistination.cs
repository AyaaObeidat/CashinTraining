namespace MessagingSystem.Models
{
    public class MessageDistination
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageId { get; private set; }
        public bool Read { get; private set; } = false;
        public MessageBox Box { get; private set; }

        private MessageDistination() { }

        private MessageDistination(Guid userId , Guid messageId, MessageBox box)
        {
            UserId = userId;
            MessageId = messageId;
            Box = box;
        }

        public static MessageDistination Create(Guid userId, Guid messageId, MessageBox box)
        {
            return new MessageDistination(userId, messageId, box);
        }

        public void SetBox(MessageBox box)
        { Box = box; }
    }
}

