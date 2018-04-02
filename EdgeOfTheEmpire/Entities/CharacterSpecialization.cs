using System.ComponentModel.DataAnnotations;

namespace EdgeOfTheEmpire.Entities
{
    public class CharacterSpecialization
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}
