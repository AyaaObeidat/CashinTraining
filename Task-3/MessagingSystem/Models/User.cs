namespace MessagingSystem.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public List<MessageDistination> Messages { get; private set; }

        private User() { }
        private User(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
        public static User Create(string name, string email)
        {

            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(email)) { throw new ArgumentNullException(); }
            return new User(name, email);
        }

        public void SetMessages(List<MessageDistination> messages)
        {
            Messages = messages;
        }
    }
}
