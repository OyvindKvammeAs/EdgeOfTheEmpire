using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.ViewModels
{
    public class SkillViewModel
    {
        public Skill Skill { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Career> Careers { get; set; }
    }
}
