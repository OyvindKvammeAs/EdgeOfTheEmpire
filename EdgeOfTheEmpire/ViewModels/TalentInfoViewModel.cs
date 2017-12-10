using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.ViewModels
{
    public class TalentInfoViewModel
    {
        public Talent Talent { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
