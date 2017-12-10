using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.ViewModels
{
    public class SpecializationInfoViewModel
    {
        public Specialization Specialization { get; set; }
        public Career Career { get; set; }
        public TalentTree TalentTree { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
