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
    }
}
