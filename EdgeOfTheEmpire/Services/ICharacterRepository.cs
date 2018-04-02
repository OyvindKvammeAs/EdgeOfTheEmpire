using EdgeOfTheEmpire.Entities;
using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Services
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> Characters { get; }
        void AddCharacter(InitialCharacter character);
        Character GetCharacter(string characterName);
        void AddBattleScarAdvance(CharacterBattleScarAdvance battleScarAdvance);
        void AddSkillAdvance(CharacterSkillAdvance skillAdvance);
        void AddSignatureAbilityAdvance(CharacterSignatureAbilityAdvance signatureAbilityAdvance);
        void AddSpecializationAdvance(CharacterSpecializationAdvance specializationAdvance);
        void AddSpecialization(Entities.CharacterSpecialization specialization);
        void AddSignatureAbility(CharacterSignatureAbility signatureAbility);
    }
}
