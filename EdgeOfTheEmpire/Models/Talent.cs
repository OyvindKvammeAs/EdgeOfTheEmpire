using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class Talent
    {
        public Talent(string name, bool isActive, bool isRanked, bool isForce, string description="")
        {            
            TalentName = name;
            IsRanked = isRanked;
            IsActive = isActive;
            IsForceTalent = isForce;
            Description = description;
        }

        public string TalentName { get; set; }
        public bool IsRanked { get; set; }
        public bool IsActive { get; set; }
        public bool IsForceTalent { get; set; }

        public string Description { get; set; }
    }
}
