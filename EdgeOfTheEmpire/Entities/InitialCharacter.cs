using System.ComponentModel.DataAnnotations;

namespace EdgeOfTheEmpire.Entities
{
    public class InitialCharacter
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Player { get; set; }
        [Required]
        public string Race { get; set; }
        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Brawn Attribute")]
        public int Brawn { get; set; }
        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Agility Attribute")]
        public int Agility { get; set; }
        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Intelligence Attribute")]
        public int Intelligence { get; set; }
        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Cunning Attribute")]
        public int Cunning { get; set; }
        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Willpower Attribute")]
        public int Willpower { get; set; }

        [Required(ErrorMessage = "Please enter a value between 1 and 6 for Presence Attribute")]        
        public int Presence { get; set; }


    }
}
