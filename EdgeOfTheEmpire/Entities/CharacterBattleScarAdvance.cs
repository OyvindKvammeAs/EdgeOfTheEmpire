using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Entities
{
    public class CharacterBattleScarAdvance
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Talent { get; set; }
    }
}
