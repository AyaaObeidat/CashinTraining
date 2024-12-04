namespace Profolio.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; private set; } = null!;
        public long? PhoneNumber { get; private set; }
        public string? LinkedinUrl { get; private set; }
        public string? GitHubUrl { get; private set; }
        public Guid UserId { get; private set; }
        private Contact() { }
        private Contact(string email, Guid userId)
        {
            Email = email;
            UserId = userId;
        }
        public static Contact Create(string email, Guid userId)
        {
            if (email == null) throw new ArgumentNullException("email doesn't be null");
            if (userId == Guid.Empty) throw new ArgumentNullException();
            return new Contact(email, userId);
        }

        public void SetEmail(string email)
        {
            if (email == null) throw new ArgumentNullException("email doesn't be null");
            Email = email;

        }
        public void SetPhoneNumber(long phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
        public void SetLinkedUrl(string linkedinUrl)
        {
            LinkedinUrl = linkedinUrl;
        }
        public void SetGitHubUrl(string gitHubUrl)
        {
            GitHubUrl = gitHubUrl;
        }
    
}
}
