using MessagingSystem.Models;

namespace MessagingSystem.Dtos.InboxDtos
{
    public class InboxDetails
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get;  set; }
        public List<Message> Messages { get;  set; }
    }
}
