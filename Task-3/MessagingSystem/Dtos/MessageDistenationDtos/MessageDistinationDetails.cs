namespace MessagingSystem.Dtos.MessageDistenationDtos
{
    public class MessageDistinationDetails
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageId { get;  set; }
        public bool Read { get;  set; } 
        public MessageBox Box { get;  set; }
    }
}
