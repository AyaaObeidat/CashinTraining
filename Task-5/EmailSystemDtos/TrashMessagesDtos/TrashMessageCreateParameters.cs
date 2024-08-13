using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemDtos.TrashMessagesDtos
{
    public class TrashMessageCreateParameters
    {
        public Guid TrashId { get;  set; }
        public Guid MessageId { get;  set; }
    }
}
