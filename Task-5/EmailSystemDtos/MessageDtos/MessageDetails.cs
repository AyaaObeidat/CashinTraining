using EmailSystemEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.MessageDtos
{
    public class MessageDetails
    {
        public Guid Id { get; set; }
        public string? Subject { get;  set; }
        public string ContentBody { get;  set; } 
        public DateTime? SentDate { get;  set; }
        public DateTime? CreatedDate { get; set; }
        public Guid SenderId { get;  set; }
        public MessageStatus Status { get; set; }
    }
}
