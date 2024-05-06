namespace MessagingSystem.Models
{
    public class MessageDistination
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; private set; }
        public Guid RecevierId { get; private set; }
        public Guid MessageId { get; private set; }
        public bool Read { get;  set; } = false;
        public MessageBox Box { get; private set; }

        private MessageDistination() { }

        private MessageDistination(Guid senderId , Guid recevierId , Guid messageId)
        {
           SenderId = senderId;
           RecevierId = recevierId;
           MessageId = messageId;
           
        }

        public static MessageDistination Create(Guid senderId, Guid recevierId, Guid messageId)
        {
            return new MessageDistination(senderId, recevierId, messageId);
        }

        public void SetMessageBox (MessageBox box)
        {
             Box = box;
        }
    }
}

