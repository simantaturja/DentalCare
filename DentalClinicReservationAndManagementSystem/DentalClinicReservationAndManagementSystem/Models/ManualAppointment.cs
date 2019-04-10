using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalClinicReservationAndManagementSystem.Models
{
    public class ManualAppointment
    {
        public int Id { get; set; }
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        public string Time { get; set; }
    }
}