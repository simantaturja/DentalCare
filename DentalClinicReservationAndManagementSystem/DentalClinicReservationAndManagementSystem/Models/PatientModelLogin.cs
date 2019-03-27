namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientModelLogin : DbContext
    {
        public PatientModelLogin()
            : base("name=PatientModelLogin")
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
