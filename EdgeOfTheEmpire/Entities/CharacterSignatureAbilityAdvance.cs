namespace EdgeOfTheEmpire.Entities
{
    public class CharacterSignatureAbilityAdvance
    {        
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string SignatureAbility { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }    
    }
}
