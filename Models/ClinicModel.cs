using System.Data.Entity;

namespace Lab6.Models
{
    public partial class ClinicModel : DbContext
    {
        public ClinicModel()
            : base("name=ClinicModelEntities")
        {
        }

        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Equipments> Equipments { get; set; }
        public virtual DbSet<Naprav> Naprav { get; set; }
        public virtual DbSet<Pacients> Pacients { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Pacients>()
            //    .HasMany(e => e.Naprav)
            //    .WithOptional(e => e.Pacients)
            //    .HasForeignKey(e => e.ID_Pacients);
        }
    }
}
