namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppointmentModel : DbContext
    {
        public AppointmentModel()
            : base("name=AppointmentModel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
