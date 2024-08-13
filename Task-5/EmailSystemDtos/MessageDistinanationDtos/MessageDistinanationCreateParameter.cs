using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.MessageDestinationDtos
{
    public class MessageDestinationCreateParameter
    {
        public Guid MessageId { get;  set; }
        public Guid ReceiverId { get;  set; }

    }
}
