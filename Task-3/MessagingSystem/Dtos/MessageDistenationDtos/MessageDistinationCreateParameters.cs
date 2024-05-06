namespace MessagingSystem.Dtos.MessageDistenationDtos
{
    public class MessageDistinationCreateParameters
    {
        public Guid SenderId { get; set; }
        public Guid RecevierId { get; set; }
        public Guid MessageId { get; set; }
    }
}
