namespace Messaging_System.Models
{
    public class User
    {
        public Guid Id { get;  set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set;} = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public Guid UserProfileId { get; private set; }

        public User() { }
        public User (string firstName , string lastName , string email , string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            if (string.IsNullOrEmpty(firstName)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(lastName)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(email)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(password)) { throw new ArgumentNullException(); }

            return new User (firstName, lastName, email, password);
        }
    }
}
