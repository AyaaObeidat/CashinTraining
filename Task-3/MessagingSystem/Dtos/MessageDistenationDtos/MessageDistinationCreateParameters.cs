namespace MessagingSystem.Dtos.MessageDistenationDtos
{
    public class MessageDistinationCreateParameters
    {
        public Guid UserId { get; set; }
        public Guid MessageId { get;  set; }
        public MessageBox Box { get; set; }
    }
}
