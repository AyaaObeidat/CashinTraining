using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.ExperiencesDtos
{
    public class ExperienceDetails
    {
        public Guid Id { get; set; }
        public string Title { get;  set; }
        public string CompanyName { get;  set; } 
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AttachmentUrl { get; set; }
        public Guid UserId { get; set; }

    }
}
