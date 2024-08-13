namespace Email_System.Models
{
    public class User : Parent
    {
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string? ImageUrl { get; private set; }
        public Guid InboxId { get; private set; }
        public Guid  OutboxId { get; private set; }
        public Guid TrashId { get; private set; }
        public List<MessageDestination>? Messages { get; set; }

        private User() { }

        private User( string fullName, string email, string password , string address)
        {
           
            FullName = fullName;
            Email = email;
            Password = password;
            Address = address;
        }

        public static User Create(string fullName, string email, string password,string address)
        {
            if (string.IsNullOrEmpty(fullName)) { throw new ArgumentNullException(); }
            if(string.IsNullOrEmpty(email)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(password)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(address)) { throw new ArgumentNullException(); }

            return new User(fullName, email, password,address);
        }

        public void SetFullName(string fullName)
        { 
            this.FullName = fullName;
        }
        public void SetEmail(string email) 
        { 
            this.Email = email;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
        public void SetAddress(string address) 
        {
            this.Address = address; 
        }
        public void SetImageUrl(string url)
        {
            this.ImageUrl = url;
        }

        public void SetMessages(List<MessageDestination> messages)
        {
            Messages = messages;
        }

        public void SetInboxId(Guid inboxId)
        {
            if (inboxId == Guid.Empty) { throw new ArgumentNullException(); }
            InboxId = inboxId; 
        }    
        public void SetOutboxId(Guid outboxId)
        {
            if (outboxId == Guid.Empty) { throw new ArgumentNullException(); }
            OutboxId = outboxId; 
        }
        public void SetTrashId(Guid trashId)
        {
            if (trashId == Guid.Empty) { throw new ArgumentNullException(); }
            TrashId = trashId; 
        }

    }
}
