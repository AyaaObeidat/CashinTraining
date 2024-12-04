using ProfolioEnums;

namespace Profolio.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public long? PhoneNumber { get; private set; }
        public string? About { get; private set; }
        public string? Education { get; private set; }
        public string? ImageUrl { get; private set; }
        public string? JobTitle { get; private set; }
        public string? CvUrl { get; private set; }
        public ProfileStatus ProfileStatus { get; private set; }
        public List<Skills> Skills { get; private set; }
        public List<Experience> Experiences { get; private set; }
        public Guid ContactId { get; private set; }

        private User() { }

        private User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            ProfileStatus = ProfileStatus.Private;
        }

        public static User Create(string fullName, string email, string password)
        {
            if (fullName == null) throw new ArgumentNullException("FullName doesn't be null");
            if (email == null) throw new ArgumentNullException("email doesn't be null");
            if (password == null) throw new ArgumentNullException("password doesn't be null");
            return new User(fullName, email, password);
        }

        public void SetFullName(string fullName)
        {
            if (fullName == null) throw new ArgumentNullException("FullName doesn't be null");
            this.FullName = fullName;
        }

        public void SetEmail(string email)
        {
            if (email == null) throw new ArgumentNullException("Email doesn't be null");
            this.Email = email;
        }

        public void SetPassword(string password)
        {
            if (password == null) throw new ArgumentNullException("Password doesn't be null");
            this.Password = password;
        }

        public void SetEduciation(long phoneNumber)
        {
            if (phoneNumber == null) throw new ArgumentNullException("PhoneNumber doesn't be null");
            this.PhoneNumber = phoneNumber;
        }

        public void SetAbout(string about)
        {
            if (about == null) throw new ArgumentNullException("About doesn't be null");
            this.About = about;
        }

        public void SetEducation(string education)
        {
            if (education == null) throw new ArgumentNullException("Education doesn't be null");
            this.Education = education;
        }
        public void SetImageUrl(string imageUrl)
        {
            if (imageUrl == null) throw new ArgumentNullException("ImageUrl doesn't be null");
            this.ImageUrl = imageUrl;
        }
        public void SetJobTitle(string jobTitle)
        {
            if (jobTitle == null) throw new ArgumentNullException("JobTitle doesn't be null");
            this.JobTitle = jobTitle;
        }
        public void SetCvUrl(string cvUrl)
        {
            if (cvUrl == null) throw new ArgumentNullException("CvUrl doesn't be null");
            this.CvUrl = cvUrl;
        }
        public void SetPrivateProfileStatus()
        {
            this.ProfileStatus = ProfileStatus.Private;
        }
        public void SetPublicProfileStatus()
        {
            this.ProfileStatus = ProfileStatus.Public;
        }

        public void SetContactId(Guid contactId)
        {
            if (contactId == Guid.Empty) throw new ArgumentNullException();
            this.ContactId = contactId;
        }

        public void SetUserSkills(List<Skills> skills)
        {
            this.Skills = skills;
        }
        public void SetUserExperiences(List<Experience> experience)
        {
            this.Experiences = experience;
        }
    }

}

