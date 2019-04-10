namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prescription")]
    public partial class Prescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int patient_id { get; set; }

        public int dentist_id { get; set; }

        [Required]
        [StringLength(255)]
        public string problems { get; set; }

        [Required]
        [StringLength(255)]
        public string medicine { get; set; }
    }
}
