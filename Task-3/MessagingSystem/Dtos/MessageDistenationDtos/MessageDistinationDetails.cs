namespace MessagingSystem.Dtos.MessageDistenationDtos
{
    public class MessageDistinationDetails
    {
        public Guid Id { get; set; }
        public Guid SenderId { get;  set; }
        public Guid RecevierId { get;  set; }
        public Guid MessageId { get;  set; }
        public bool Read { get; set; } = false;
        public MessageBox Box { get;  set; }
    }
}
