using MessagingSystem.Models;

namespace MessagingSystem.Dtos.UserDtos
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FullName { get;  set; } 
        public string Email { get;  set; }
        public List<MessageDistination> Messages { get;  set; }
    }
}
