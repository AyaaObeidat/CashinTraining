namespace Profolio.Models
{
    public class Experience
    {
        public Guid Id { get; set; }
        public string Title { get; private set; } = null!;
        public string CompanyName { get; private set; } = null!;
        public string? Description { get; private set; }
        public DateTime? StartDate { get;private set; }
        public DateTime? EndDate { get; private set; }
        public string? AttachmentUrl { get; private set; }
        public Guid UserId { get; private set; }

        private Experience() { }
        private Experience(string title, string companyName,Guid userId)
        {
           
            Title = title;
            CompanyName = companyName;
            UserId = userId;
        }
        public static Experience Create ( string title, string companyName, Guid userId)
        {
            if (title == null) throw new ArgumentNullException("Title doesn't be null");
            if (companyName == null) throw new ArgumentNullException("Company name doesn't be null");
            if (userId == Guid.Empty) throw new ArgumentNullException();
            return new Experience(title, companyName,userId);
        }

        public void SetTitle(string title)
        {
            if (title == null) throw new ArgumentNullException("Title doesn't be null");
            this.Title = title;
        }
        public void SetCompanyName(string companyName)
        {
            if (companyName == null) throw new ArgumentNullException("Company name doesn't be null");
            this.CompanyName = companyName;
        }
        public void SetDescription(string description)
        {
            if (description == null) throw new ArgumentNullException("Description doesn't be null");
            this.Description = description;

        }
        public void SetAttachmentUrl(string attachmentUrl)
        {
            if (attachmentUrl == null) throw new ArgumentNullException("AttachmentUrl doesn't be null");
            this.AttachmentUrl = attachmentUrl;
        }

        public void SetStartDate(DateTime startDate)
        {
            this.StartDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }
    }
}
