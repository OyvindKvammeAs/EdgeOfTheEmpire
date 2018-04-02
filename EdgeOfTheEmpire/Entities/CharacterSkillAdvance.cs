using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Entities
{
    public class CharacterSkillAdvance
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Skill { get; set; }
        public int Rank { get; set; }
    }
}
