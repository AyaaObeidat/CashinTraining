using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.SkillsDtos
{
    public class SkillsCreateParameters
    {
        public string Title { get;  set; } 
        public Guid UserId { get; set; }
    }
}
