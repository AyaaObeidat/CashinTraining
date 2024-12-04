using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.ContactDtos
{
    public class ContactDetails
    {
        public Guid Id { get; set; }
        public string Email { get;  set; }
        public long? PhoneNumber { get;  set; }
        public string? LinkedinUrl { get;  set; }
        public string? GitHubUrl { get;  set; }
        public Guid UserId { get;  set; }
    }
}
