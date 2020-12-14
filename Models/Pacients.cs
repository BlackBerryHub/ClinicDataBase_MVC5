namespace Lab6.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Pacients
    {
        [Key]
        public int ID_Pacinents { get; set; }

        [Display(Name = "Ім'я пацієнта")]
        [StringLength(20, ErrorMessage = "Ім'я пацієнта більше за 20 символів")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ім'я пацієнта порожнє")]
        public string Name { get; set; }

        [Display(Name = "Прізвище пацієнта")]
        [StringLength(40, ErrorMessage = "Прізвище пацієнта більше за 40 символів")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Прізвище пацієнта порожнє")]
        public string LastName { get; set; }
    }
}
