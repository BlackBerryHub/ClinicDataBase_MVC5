namespace Lab6.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Equipments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipments()
        {
            Documents = new HashSet<Documents>();
        }

        [Key]
        public int ID_Equipment { get; set; }

        [Display(Name = "Назва обладнання")]
        [StringLength(30, ErrorMessage = "Назва обладнання більша за 30 символів")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Назва обладнання порожня")]
        public string nameEquipment { get; set; }

        [Display(Name = "Призначення обладнання")]
        [StringLength(50, ErrorMessage = "Призначення обладнання більше за 50 символів")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Призначення обладнання порожнє")]
        public string Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
