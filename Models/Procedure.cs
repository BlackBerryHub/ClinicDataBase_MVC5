namespace Lab6.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Procedure")]
    public partial class Procedure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Procedure()
        {
            Documents = new HashSet<Documents>();
            Naprav = new HashSet<Naprav>();
        }

        [Key]
        public int ID_Procedure { get; set; }

        [Display(Name = "����� ���������")]
        [StringLength(40, ErrorMessage = "����� ��������� ����� �� 40 �������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "����� ��������� �������")]
        public string Name { get; set; }

        [Display(Name = "������� ���������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "������� ��������� �������")]
        public int? Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Documents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Naprav> Naprav { get; set; }
    }
}
