namespace Lab6.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Naprav")]
    public partial class Naprav
    {
        [Key]
        public int ID_Naprav { get; set; }

        [Display(Name = "ID ��������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID �������� ������")]
        public int ID_Pacients { get; set; }

        [Display(Name = "ID ���������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID ��������� ������")]
        public int ID_Procedure { get; set; }

    }
}
