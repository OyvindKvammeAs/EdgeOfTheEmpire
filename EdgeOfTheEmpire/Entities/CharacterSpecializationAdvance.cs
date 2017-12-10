
namespace EdgeOfTheEmpire.Entities
{
    public class CharacterSpecializationAdvance
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Specialization { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
