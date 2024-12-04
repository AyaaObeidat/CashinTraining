using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.SkillsDtos
{
    public class SkillsUpdateParameters
    {
        public Guid Id { get; set; }
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }
    }
}
