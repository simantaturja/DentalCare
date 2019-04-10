namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScheduleModel : DbContext
    {
        public ScheduleModel()
            : base("name=ScheduleModel1")
        {
        }

        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                .Property(e => e.dentist_name)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.daysweek)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.times)
                .IsUnicode(false);
        }
    }
}
