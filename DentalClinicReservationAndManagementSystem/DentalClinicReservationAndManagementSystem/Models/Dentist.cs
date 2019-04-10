namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dentist")]
    public partial class Dentist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string institute { get; set; }

        [Required]
        [StringLength(50)]
        public string contact { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string bloodgroup { get; set; }

        [Required]
        public string password { get; set; }

        public int isVerfied { get; set; }

        public int isAvailable { get; set; }

        
    }
}
