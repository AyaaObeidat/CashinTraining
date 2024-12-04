using ProfolioDtos.ContactDtos;
using ProfolioDtos.ExperiencesDtos;
using ProfolioDtos.SkillsDtos;
using ProfolioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.UserDtos
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public string Password { get; set; } 
        public long? PhoneNumber { get;  set; }
        public string? About { get;  set; }
        public string? Education { get;  set; }
        public string? ImageUrl { get;  set; }
        public string? JobTitle { get;  set; }
        public string? CvUrl { get;  set; }
        public ProfileStatus ProfileStatus { get;  set; }
        public List<SkillsDetails> Skills { get;  set; }
        public List<ExperienceDetails> Experiences { get;  set; }
        public ContactDetails Contact { get;  set; }

    }
}
