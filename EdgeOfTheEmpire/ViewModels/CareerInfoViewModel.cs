using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.ViewModels
{
    public class CareerInfoViewModel
    {
        public Career Career { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}
