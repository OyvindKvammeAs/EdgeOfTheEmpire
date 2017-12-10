using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class Skill
    {        
        public Skill(int id, string name, string description,Attribute attribute, SkillCategory category)
        {
            SkillId = id;
            Name = name;
            Description = description;
            AssosiatedAttribute = attribute;
            SkillCategory = category;
        }

        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public Attribute AssosiatedAttribute { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
