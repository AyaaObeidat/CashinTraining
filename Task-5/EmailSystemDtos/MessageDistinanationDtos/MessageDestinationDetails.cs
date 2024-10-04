using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSystemDtos.MessageDtos;
using EmailSystemDtos.UserDtos;

namespace EmailSystemDtos.MessageDistinanationDtos
{
    public class MessageDestinationDetails
    {

        public Guid MessageId { get;  set; }
        public Guid ReceiverId { get;  set; }
    }
}
