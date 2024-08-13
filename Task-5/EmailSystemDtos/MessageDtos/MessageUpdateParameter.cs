using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.MessageDtos
{
    public class MessageUpdateParameter
    {
        public Guid MessageId {  get; set; }
        public string Subject { get; set; }
        public string ContentBody { get; set; }

    }
}
