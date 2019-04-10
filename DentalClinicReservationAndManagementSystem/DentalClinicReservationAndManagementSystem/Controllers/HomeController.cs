using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DentalClinicReservationAndManagementSystem.Models;

namespace DentalClinicReservationAndManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            DentistModel dm = new DentistModel();
            List<Dentist> dentistList1 = dm.Dentists.ToList();
            List<Dentist> dentistList = new List<Dentist>();
            foreach (var dentist in dentistList1)
            {
                if (dentist.isAvailable == 1)
                {
                    dentistList.Add(dentist);
                }

            }
            ViewBag.dentistList = dentistList;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();  
        }
        public ActionResult Dentists()
        {
            return View();
        }
        public ActionResult DentistLogin()
        {
            if (Session["LoggedDentistID"] != null) return RedirectToAction("DentistPanel");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DentistLogin(DentistLogin dentist)
        {
            if ( ModelState.IsValid )
            {
                using (DentistLoginModel dm = new DentistLoginModel())
                {
                    var v = dm.Dentists.Where(a => a.username.Equals(dentist.username) && a.password.Equals(dentist.password)).FirstOrDefault();
                    if ( v != null )
                    {
                        Session["LoggedDentistID"] = v.Id.ToString();
                        Session["LoggedDentistUsername"] = v.username.ToString();
                        Session["LoggedDentistFullName"] = v.name.ToString();
                       return RedirectToAction("DentistPanel");
                    } 
                    else
                    {
                        dentist.LoginErrorMessage = "Wrong username or password.";
                        return View("DentistLogin",dentist);
                    }
                }
            }
            return RedirectToAction("DentistLogin");
        }
        public ActionResult AfterDentistLogin()
        {
            
            return View();
       
        }
        public ActionResult DentistPanel()
        {
            return View();
        }
        public ActionResult PatientLogin()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientLogin(PatientLogin patient)
        {
            if (ModelState.IsValid)
            {
                using (PatientLoginModel pm = new PatientLoginModel())
                {
                    var v = pm.Patients.Where(a => a.username.Equals(patient.username) && a.password.Equals(patient.password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedPatientID"] = v.Id.ToString();
                        Session["LoggedPatientUsername"] = v.username.ToString();
                        Session["LoggedPatientFullName"] = v.name.ToString();
                        return RedirectToAction("PatientPanel");
                    }
                    else
                    {
                        patient.LoginErrorMessage = "Wrong Username or Password";
                        return View("PatientLogin", patient);
                    }
                }
            }
            return RedirectToAction("PatientLogin");
        }
        public ActionResult PatientPanel()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Appointment()
        {
            /*if (Session["LoggedPatientUsername"] == null) return RedirectToAction("PatientLogin");
            DentistModel dm = new DentistModel();
            List<Dentist> dentistList1 = dm.Dentists.ToList();
            List<Dentist> dentistList = new List<Dentist>();
            foreach ( var dentist in dentistList1 )
            {
                if ( dentist.isAvailable == 1 )
                {
                    dentistList.Add(dentist);
                }
                
            }
            ViewBag.dentistList = dentistList;*/
            return View();
        }
        [HttpPost]
        public ActionResult Appointment(FormCollection collection)
        {
            foreach (string key in collection.AllKeys)
            {
                Response.Write("Key = " + key + " , ");
                Response.Write("Value = " + collection[key]);
                Response.Write("<br/>");
            }

            return View();
        }
        
        public ActionResult PatientRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientRegister(Patient patientr)
        {
            ViewBag.Message1 = "";
            ViewBag.Message2 = "";
            if (ModelState.IsValid)
            {
                using (PatientRegisterModel prm = new PatientRegisterModel())
                {
                    var v1 = prm.Patients.Where(a => a.username.Equals(patientr.username)).FirstOrDefault();
                    if (v1 != null)
                    {
                        ViewBag.Message2 = "Username already exists";
                        return View("PatientRegister", patientr);
                    }
                    var v2 = prm.Patients.Where(a => a.email.Equals(patientr.email)).FirstOrDefault();
                    if ( v2 != null )
                    {
                        ViewBag.Message1 = "Email already exists";
                        return View("PatientRegister", patientr);
                    }
                    else
                    {
                        prm.Patients.Add(patientr);
                        prm.SaveChanges();
                        return RedirectToAction("PatientPanel");
                    }
                    
                        
                    
                    
                }
            }
            return RedirectToAction("PatientLogin");
            
        }
        
        public ActionResult SelectDentist()
        {
            if (Session["LoggedPatientUsername"] == null) return RedirectToAction("PatientLogin");
            DentistModel dm = new DentistModel();
            List<Dentist> dentistList1 = dm.Dentists.ToList();
            List<Dentist> dentistList = new List<Dentist>();
            foreach (var dentist in dentistList1)
            {
                if (dentist.isAvailable == 1)
                {
                    dentistList.Add(dentist);
                }

            }
            ViewBag.dentistList = dentistList;
            return View();
        }
        public ActionResult SelectedAppointmentList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SelectedAppointmentList(FormCollection form)
        {
            string option = form["ddl"].ToString();
            ViewBag.selectedDentistOption = option;
            return View();
        }

        public ActionResult MyAppointments()
        {
            AppointmentModel dm = new AppointmentModel();
            List<Appointment> appointmentList1 = dm.Appointments.ToList();
            List<Appointment> appointmentList = new List<Appointment>();
            string s = Session["LoggedPatientID"].ToString();
            int n = Convert.ToInt32(s);
            foreach (var appointment in appointmentList1)
            {
                if (appointment.patient_id == n)
                {
                    appointmentList.Add(appointment);
                }

            }
            ViewBag.appointmentList = appointmentList;
            return View();
        }


        public ActionResult AppointmentList()
        {

            AppointmentModel dm = new AppointmentModel();
            List<Appointment> appointmentList1 = dm.Appointments.ToList();
            List<Appointment> appointmentList = new List<Appointment>();
            string s = Session["LoggedDentistID"].ToString();
            int n = Convert.ToInt32(s);
            foreach (var appointment in appointmentList1)
            {
                if (appointment.dentist_id == n)
                {
                    appointmentList.Add(appointment);
                }

            }
            ViewBag.appointmentList = appointmentList;
            return View();
        }

        public ActionResult CreatePrescription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePrescription(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                using (PrescriptionModel prm = new PrescriptionModel())
                {

                   
                    prm.Prescriptions.Add(prescription);
                    prm.SaveChanges();
                    return RedirectToAction("DentistPanel");
                    //}

                }
            }
            return View();
        }

        public ActionResult TakeAppointment()
        {
             DentistModel dm = new DentistModel();
            List<Dentist> appointmentList2 = dm.Dentists.ToList();
            ViewBag.appointmentList2 = appointmentList2;
            return View();
        }
        [HttpPost]
        public ActionResult TakeAppointment(Appointment appointment)
        {
           
            ViewBag.Message2 = "";
            if (ModelState.IsValid)
            {
                using (AppointmentModel prm = new AppointmentModel())
                {

                    /*var v = prm.Appointments.Where(a => a.dentist_id.Equals(appointment.dentist_id) && a.datetime.Equals(appointment.datetime)).FirstOrDefault();
                    if (v != null)
                    {
                        ViewBag.Message2 = "Time slot is not avaible";
                        return View("TakeAppointment", appointment);
                    }*/
                    //else
                    //{
                        prm.Appointments.Add(appointment);
                        prm.SaveChanges();
                        return RedirectToAction("PatientPanel");
                    //}
   
                }
            }

            return View();
        }
        //public ActionResult SeeAppointments()
      //  {
          //  return View();
        //}
        //[HttpPost]
        /*public ActionResult SeeAppointments(Appointment appointment)
        {
            AppointmentModel am = new AppointmentModel();
            List<Appointment> aList = am.Appointments.ToList();
            List<Appointment> fList = new List<Appointment>();
            foreach ( Appointment ap in aList )
            {
                if ( appointment.dentist_id == ap.dentist_id )
                {
                    fList.Add(ap);
                }
            }
            ViewBag.fList = fList;
            return View();
        }*/

    }
}
