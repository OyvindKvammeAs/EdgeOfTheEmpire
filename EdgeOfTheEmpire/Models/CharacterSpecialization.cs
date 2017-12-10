using EdgeOfTheEmpire.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class CharacterSpecialization
    {
        public string SpecializationName { get; set; }
        public virtual Specialization Specialization { get; set; }
        public IEnumerable<CharacterSpecializationAdvance> BoughtAdvance { get; set; }

        public int GetBoughtTalentCost()
        {
            int totalCost = 0;
            foreach (var specializationAdvance in BoughtAdvance)
            {
                totalCost += specializationAdvance.Row * 5;
            }

            return totalCost;
        }

        public int GetAvailableTalentCost()
        {
            return 300 - GetBoughtTalentCost();
        }
    }
}
