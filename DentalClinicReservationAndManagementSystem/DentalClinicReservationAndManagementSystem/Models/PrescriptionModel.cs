namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrescriptionModel : DbContext
    {
        public PrescriptionModel()
            : base("name=PrescriptionModel")
        {
        }

        public virtual DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>()
                .Property(e => e.problems)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.medicine)
                .IsUnicode(false);
        }
    }
}
