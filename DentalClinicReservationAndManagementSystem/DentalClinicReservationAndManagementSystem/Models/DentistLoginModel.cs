namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DentistLoginModel : DbContext
    {
        public DentistLoginModel()
            : base("name=DentistLoginModel")
        {
        }

        public virtual DbSet<Dentist> Dentists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
