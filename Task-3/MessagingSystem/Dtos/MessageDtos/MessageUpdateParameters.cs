namespace MessagingSystem.Dtos.MessageDtos
{
    public class MessageUpdateParameters
    {
        public Guid Id { get; set; }
        public string Subject { get;  set; } 
        public string ContentBody { get;  set; } 
    }
}
