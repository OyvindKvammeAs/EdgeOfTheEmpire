using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class TalentTree
    {
        public TalentTree(Specialization specialization, IList<Talent> talentTreeData)
        {
            Specialization = specialization;
            RowAndColumn currentElement = new RowAndColumn();
            TalentTreeData = new Dictionary<RowAndColumn, Talent>();
            foreach (var talent in talentTreeData)
            {
                TalentTreeData.Add(currentElement, talent);
                currentElement = currentElement.Next();
            }            
        }
        public Specialization Specialization { get; set; }
        public IDictionary<RowAndColumn, Talent> TalentTreeData { get; set; }
        public bool HasTalent(Talent talent)
        {
            foreach (var key in TalentTreeData.Keys)
            {
                if (TalentTreeData[key] == talent) return true;
            }

            return false;
        }

        public IList<int> GetTalentInfo(Talent talent)
        {
            IList<int> result = new List<int>();
            foreach (var key in TalentTreeData.Keys)
            {
                if (TalentTreeData[key] == talent) result.Add(5 * key.Row);
            }

            return result;
        }
    }
}
