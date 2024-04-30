namespace MessagingSystem.Dtos.UserProfileDtos
{
    public class UserProfileDetails
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public Guid UserId { get; set; }
        public Guid InboxId { get;  set; }
        public Guid Id { get; set; }
    }
}
