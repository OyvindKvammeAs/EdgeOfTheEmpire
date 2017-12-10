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

        public void AddCharacter(InitialCharacter character)
        {
            characterDbContext.Characters.Add(character);
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
                var advancedChar = new Character(character, specializationAdvances);
                characters.Add(advancedChar);
            }
            return characters;
        }

        private IList<CharacterSpecializationAdvance> GetCharacterSpecializationAdvances(InitialCharacter character)
        {
            return characterDbContext.CharacterSpecializationAdvances.Where(x => x.CharacterId == character.Id).ToList();
        }
    }
}
