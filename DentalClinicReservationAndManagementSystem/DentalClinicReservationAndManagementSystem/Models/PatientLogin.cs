namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class PatientLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
