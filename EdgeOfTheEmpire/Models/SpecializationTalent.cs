﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class SpecializationTalent
    {
        public int SpecializationTalentId { get; set; }
        public int SpecializationId { get; set; }
        public int TalentId { get; set; }
    }
}
