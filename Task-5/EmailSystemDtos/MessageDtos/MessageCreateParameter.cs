using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.MessageDtos
{
    public class MessageCreateParameter
    {
        public Guid SenderId { get;  set; }

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(50, ErrorMessage = "Subject cannot be longer than 50 characters.")]
        public string? Subject { get;  set; }

        [Required(ErrorMessage ="ContentBody is required")]
        public string ContentBody { get;  set; } 
    }
}
