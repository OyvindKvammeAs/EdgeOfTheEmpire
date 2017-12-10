using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class Career
    {
        public Career(int careerId, string careerName)
        {
            CareerId = careerId;
            CareerName = careerName;
        }
        public int CareerId { get; set; }
        public string CareerName { get; set; }
    }
}
