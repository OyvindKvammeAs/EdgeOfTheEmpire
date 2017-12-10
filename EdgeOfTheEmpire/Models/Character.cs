using EdgeOfTheEmpire.Entities;
using System;
using System.Collections.Generic;

namespace EdgeOfTheEmpire.Models
{
    public class Character
    {
        private InitialCharacter initial;
        private IList<CharacterSpecializationAdvance> specializationAdvances;

        public Character(InitialCharacter initial, IList<CharacterSpecializationAdvance> specializationAdvances)
        {
            this.initial = initial;
            this.specializationAdvances = specializationAdvances;
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
