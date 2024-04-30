namespace MessagingSystem.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Bio { get; private set; } = null!;
        public Guid UserId { get; private set; }
        public Guid InboxId { get; private set; }

        public UserProfile() { }
        public UserProfile(Guid userId, string fullName, string email, string bio)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Bio = bio;
        }
        public static UserProfile Create(Guid userId, string fullName, string email, string bio)
        {
            if (string.IsNullOrEmpty(fullName)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(email)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(bio)) { throw new ArgumentNullException(); }
            return new UserProfile(userId, fullName, email, bio);
        }
    }
}
