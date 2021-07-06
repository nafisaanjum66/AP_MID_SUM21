using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    
    public class HMSController : Controller
    {
        HMSEntities context = new HMSEntities();
        // GET: HMS
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login u)
        {
            
            if (ModelState.IsValid)
            {
                var log = context.Logins.Where(l => l.Username == u.Username && l.Password == u.Password);
                if (log.FirstOrDefault() != null)
                {
                    Session["Username"] = log.FirstOrDefault().Username;

                    return RedirectToAction("Dashboard");
                }
                
            }

            return View();
        }
       // [Authorize]
        public ActionResult Dashboard()
        {
            //context.
            return View();
        }
        public ActionResult Details(string username, Login u)
        {
            var d = context.Doctors.FirstOrDefault(l => l.Username == username);
            return View(d);

        }
        public ActionResult Edit(string id)
        {
            var doc = context.Doctors.FirstOrDefault(d => d.Username == id);
            return View(doc);
        }
        [HttpPost]
        public ActionResult Edit(Doctor doc)
        {
            //var doc = context.Doctors.FirstOrDefault(l => l.Username == username);
            var oldd = context.Doctors.FirstOrDefault(d => d.Username == doc.Username);
            context.Entry(oldd).CurrentValues.SetValues(doc);
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ActionResult Patient()
        {
            var pat = context.Patients.ToList();
            return View(pat);
        }
        /*public ActionResult pCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult pCreate(Patient p)
        {
            context.Patients.Add(p);
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }*/
        public ActionResult pEdit(string id)
        {
            var p = context.Patients.FirstOrDefault(e => e.Username == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult pEdit(Patient p)
        {
            var oldp = context.Patients.FirstOrDefault(e => e.Username == p.Username);
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
            return RedirectToAction("Dashboard");

        }
        public ActionResult pDetails(string id)
        {
            var p = context.Patients.FirstOrDefault(e => e.Username == id);
            return View(p);
        }
        public ActionResult pDelete(string id)
        {
            var p = context.Patients.FirstOrDefault(e => e.Username == id);
            return View(p);
        }
        [HttpPost]
        [ActionName("pDelete")]
        public ActionResult Deletepat(string id)
        {
            var pat = context.Patients.FirstOrDefault(e => e.Username == id);
            context.Patients.Remove(pat);
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}