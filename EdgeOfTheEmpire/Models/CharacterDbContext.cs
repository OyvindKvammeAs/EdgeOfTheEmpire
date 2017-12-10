using EdgeOfTheEmpire.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Models
{
    public class CharacterDbContext :DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options)
        {

        }
        public DbSet<InitialCharacter> Characters { get; set; }      
        public DbSet<CharacterSpecializationAdvance> CharacterSpecializationAdvances { get; set; }
        public DbSet<CharacterSkillAdvance> CharacterSkillAdvances { get; set; }
        public DbSet<CharacterSignatureAbilityAdvance> CharacterSignatureAbilityAdvances { get; set; }
    }
}
