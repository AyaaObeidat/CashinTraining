﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfolioDtos.SkillsDtos
{
    public class SkillsDetails
    {
        public Guid Id { get; set; }
        public string Title { get;  set; } 
        public string Description { get;  set; }
        public Guid UserId { get;  set; }
    }
}
