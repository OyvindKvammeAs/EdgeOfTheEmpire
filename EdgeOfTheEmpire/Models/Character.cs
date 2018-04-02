using EdgeOfTheEmpire.Entities;
using System;
using System.Collections.Generic;

namespace EdgeOfTheEmpire.Models
{
    public class Character
    {
        private InitialCharacter initial;
        private IList<CharacterSpecializationAdvance> specializationAdvances;
        private IList<CharacterSkillAdvance> skillAdvance;
        private IList<CharacterSignatureAbilityAdvance> signatureAbilityAdvance;
        private IList<CharacterBattleScarAdvance> battleScarAdvance;

        public Character(InitialCharacter initial, 
            IList<CharacterSpecializationAdvance> specializationAdvances,
            IList<CharacterSkillAdvance> skillAdvance,
            IList<CharacterSignatureAbilityAdvance> signatureAbilityAdvance,
            IList<CharacterBattleScarAdvance> battleScarAdvance

            )
        {
            this.initial = initial;
            this.specializationAdvances = specializationAdvances;
            this.skillAdvance = skillAdvance;
            this.signatureAbilityAdvance = signatureAbilityAdvance;
            this.battleScarAdvance = battleScarAdvance;
        }
        public String Name => initial.Name;
        public string Race => initial.Race;

        public int Brawn => initial.Brawn;
        public int Agility => initial.Agility;
        public int Intelligence => initial.Intelligence;
        public int Cunning => initial.Cunning;
        public int Willpower => initial.Willpower;
        public int Presence => initial.Presence;


    }
}
