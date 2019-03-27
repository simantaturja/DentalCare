namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DentistModel : DbContext
    {
        public DentistModel()
            : base("name=DentistModel3")
        {
        }

        public virtual DbSet<Dentist> Dentists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.institute)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.bloodgroup)
                .IsUnicode(false);

            modelBuilder.Entity<Dentist>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
