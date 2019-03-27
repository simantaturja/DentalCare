namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientModel : DbContext
    {
        public PatientModel()
            : base("name=PatientModel")
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

            modelBuilder.Entity<Patient>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.bloodgroup)
                .IsUnicode(false);
        }
    }
}
