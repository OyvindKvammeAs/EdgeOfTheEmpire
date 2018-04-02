using EdgeOfTheEmpire.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdgeOfTheEmpire.Models
{
    public class CharacterDbContext :DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> options) : base(options)
        {

        }
        public DbSet<InitialCharacter> Characters { get; set; }
        public DbSet<EdgeOfTheEmpire.Entities.CharacterSpecialization> CharacterSpecializations { get; set; }
        public DbSet<CharacterSpecializationAdvance> CharacterSpecializationAdvances { get; set; }
        public DbSet<CharacterSkillAdvance> CharacterSkillAdvances { get; set; }
        public DbSet<CharacterSignatureAbility> CharacterSignatureAbilities { get; set; }        
        public DbSet<CharacterSignatureAbilityAdvance> CharacterSignatureAbilityAdvances { get; set; }
        public DbSet<CharacterBattleScarAdvance> CharacterBattleScarAdvances { get; set; }
    }
}
