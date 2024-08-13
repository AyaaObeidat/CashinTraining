using EmailSystemDtos.MessageDistinanationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.UserDtos
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FullName { get;  set; }
        public string Email { get;  set; } 
        public string Password { get; set; } 
        public string Address { get; set; } 
        public string? ImageUrl { get; set; }
        public Guid InboxId { get; set; }
        public Guid OutboxId { get; set; }
        public Guid TrashId { get; set; }
        public List<MessageDestinationDetails>? Messages { get; set; }
    }
}
