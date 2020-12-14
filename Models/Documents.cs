namespace Lab6.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Documents
    {
        [Key]
        public int ID_Documents { get; set; }

        [Display(Name = "ID ����������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID ���������� ������")]
        public int ID_Equipment { get; set; }

        [Display(Name = "ID ���������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID ��������� ������")]
        public int ID_Procedure { get; set; }

        public virtual Equipments Equipments { get; set; }

        public virtual Procedure Procedure { get; set; }
    }
}
