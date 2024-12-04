using ProfolioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.UserDtos
{
    public class UserUpdateParameters
    {
        public Guid Id { get; set; }
        public string NewFullName { get;  set; }
        public string NewPassword { get;  set; } 
        public string CurrentPassword { get; set; }
        public long NewPhoneNumber { get;  set; }
        public string NewAbout { get;  set; }
        public string NewEducation { get; set; }
        public string NewImageUrl { get; set; }
        public string NewJobTitle { get; set; }
        public string NewCvUrl { get; set; }
    }
}
