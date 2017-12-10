using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class Specialization
    {
        public Specialization(int id, string name, Career career)
        {
            SpecializationId = id;
            SpecializationName = name;
            Career = career;        
        }

        public int SpecializationId { get; set; }
        public Career Career { get; set; }
        public string SpecializationName { get; set; }

    }
}
