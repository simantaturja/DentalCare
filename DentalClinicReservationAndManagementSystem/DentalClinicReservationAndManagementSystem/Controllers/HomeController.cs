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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DentistLogin(Dentist dentist)
        {
            if ( ModelState.IsValid )
            {
                using (DentistModel dm = new DentistModel())
                {
                    var v = dm.Dentists.Where(a => a.username.Equals(dentist.username) && a.password.Equals(dentist.password)).FirstOrDefault();
                    if ( v != null )
                    {
                        //Session["LoggedDentistID"] = v.Id.ToString();
                        //Session["LoggedDentistFullName"] = v.Name.ToString();
                       return RedirectToAction("DentistPanel");
                    } 
                }
            }
            return View(dentist);
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
        public ActionResult PatientLogin(Patient patient)
        {
            return View(patient);
        }
    }
}
