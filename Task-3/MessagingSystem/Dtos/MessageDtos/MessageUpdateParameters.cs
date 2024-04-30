namespace MessagingSystem.Dtos.MessageDtos
{
    public class MessageUpdateParameters
    {
        public Guid id { get; set; }
        public string SenderEmail { get; set; }
        public string Content { get; set; }
    }
}
