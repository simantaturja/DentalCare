namespace DentalClinicReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class PatientRegister
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name required")]
        public string name { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Username required")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        [Display(Name ="Email ID")]
        public string email { get; set; }

      
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address required")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "DOB required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name ="Date of Birth")]
        public string dateofbirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact required")]
        [Display(Name = "Contact")]
        public string contact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "BG required")]
        [Display(Name = "Blood Group")]
        public string bloodgroup { get; set; }


        
    }
}
