namespace Profolio.Models
{
    public class Skills
    {
        public Guid Id { get; set; }
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public Guid UserId { get; private set; }

        private Skills() { }
        private Skills(string title, Guid userId)
        {
            Title = title;
            UserId = userId;
        }
        public static Skills Create(string title, Guid userId)
        {
            if (title == null) throw new ArgumentNullException("Title doesn't be null");
            if (userId == Guid.Empty) throw new ArgumentNullException();
            return new Skills(title, userId);
        }

        public void SetTitle(string title)
        {
            if (title == null) throw new ArgumentNullException("Title doesn't be null");
            this.Title = title;
        }
        public void SetDescription(string description)
        {
            if (description == null) throw new ArgumentNullException("Description doesn't be null");
            this.Description = description;
        }
    }

}

