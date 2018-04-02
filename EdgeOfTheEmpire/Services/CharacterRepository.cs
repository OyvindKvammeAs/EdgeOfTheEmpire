using EdgeOfTheEmpire.Entities;
using EdgeOfTheEmpire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private CharacterDbContext characterDbContext;
        private IList<Character> characters;

        public CharacterRepository(CharacterDbContext characterDbContext)
        {
            this.characterDbContext = characterDbContext;
            characters = CreateCharacters();
        }

        public IEnumerable<Character> Characters => characters;

        public void AddBattleScarAdvance(CharacterBattleScarAdvance battleScarAdvance)
        {
            characterDbContext.CharacterBattleScarAdvances.Add(battleScarAdvance);
            characterDbContext.SaveChanges();
        }

        public void AddCharacter(InitialCharacter character)
        {
            characterDbContext.Characters.Add(character);
            characterDbContext.SaveChanges();
        }

        public void AddSignatureAbilityAdvance(CharacterSignatureAbilityAdvance signatureAbilityAdvance)
        {
            characterDbContext.CharacterSignatureAbilityAdvances.Add(signatureAbilityAdvance);
            characterDbContext.SaveChanges();
        }

        public void AddSkillAdvance(CharacterSkillAdvance skillAdvance)
        {
            characterDbContext.CharacterSkillAdvances.Add(skillAdvance);
            characterDbContext.SaveChanges();
        }

        public void AddSpecializationAdvance(CharacterSpecializationAdvance specializationAdvance)
        {
            characterDbContext.CharacterSpecializationAdvances.Add(specializationAdvance);
            characterDbContext.SaveChanges();
        }

        public void AddSpecialization(Entities.CharacterSpecialization specialization)
        {
            characterDbContext.CharacterSpecializations.Add(specialization);
            characterDbContext.SaveChanges();
        }

        public void AddSignatureAbility(CharacterSignatureAbility signatureAbility)
        {
            characterDbContext.CharacterSignatureAbilities.Add(signatureAbility);
            characterDbContext.SaveChanges();
        }

        public Character GetCharacter(string characterName)
        {
            return characters.First<Character>(x => x.Name.Equals(characterName));
        }

        private IList<Character> CreateCharacters()
        {
            IList<Character> characters = new List<Character>();
            foreach (var character in characterDbContext.Characters)
            {
                var specializationAdvances = GetCharacterSpecializationAdvances(character);
                var skillAdvances = GetCharacterSkillAdvances(character);
                var battleScarAdvances = GetCharacterBattleScarAdvances(character);
                var signatureAbilityAdvances = GetCharacterSignatureAbilitiyAdvances(character);
                var advancedChar = new Character(character, specializationAdvances, skillAdvances, signatureAbilityAdvances, battleScarAdvances);
                characters.Add(advancedChar);
            }
            return characters;
        }

        private IList<CharacterSpecializationAdvance> GetCharacterSpecializationAdvances(InitialCharacter character)
        {
            return characterDbContext.CharacterSpecializationAdvances.Where(x => x.CharacterId == character.Id).ToList();
        }

        private IList<CharacterBattleScarAdvance> GetCharacterBattleScarAdvances(InitialCharacter character)
        {
            return characterDbContext.CharacterBattleScarAdvances.Where(x => x.CharacterId == character.Id).ToList();
        }

        private IList<CharacterSkillAdvance> GetCharacterSkillAdvances(InitialCharacter character)
        {
            return characterDbContext.CharacterSkillAdvances.Where(x => x.CharacterId == character.Id).ToList();
        }

        private IList<CharacterSignatureAbilityAdvance> GetCharacterSignatureAbilitiyAdvances(InitialCharacter character)
        {
            return characterDbContext.CharacterSignatureAbilityAdvances.Where(x => x.CharacterId == character.Id).ToList();
        }

        private IList<Entities.CharacterSpecialization> GetCharacterSpecializations(InitialCharacter character)
        {
            return characterDbContext.CharacterSpecializations.Where(x => x.CharacterId == character.Id).ToList();
        }

        private IList<Entities.CharacterSignatureAbility> GetCharacterSignatureAbilities(InitialCharacter character)
        {
            return characterDbContext.CharacterSignatureAbilities.Where(x => x.CharacterId == character.Id).ToList();
        }

        
    }
}
