namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int dentist_id { get; set; }

        [Required]
        [StringLength(255)]
        public string dentist_name { get; set; }

        public int totalSlots { get; set; }

        [Required]
        [StringLength(1)]
        public string daysweek { get; set; }

        [Required]
        [StringLength(1)]
        public string times { get; set; }
    }
}
