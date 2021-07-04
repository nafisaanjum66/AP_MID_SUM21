using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using Task1.Models.Database;

using Task1.Models.ViewModel;

namespace Task1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard()
        {

            Database db = new Database();
            StudentDepartment data = new StudentDepartment();
            data.Departments = db.Departments.GetAll();
            data.Students = db.Students.GetAll();
            return View(data);
        }
        public ActionResult Department()
        {
            Database db = new Database();
            var departments = db.Departments.GetAll();

            return View(departments);
        }
        public ActionResult Create()
        {
            Student s = new Student();
            Database db = new Database();
            StudentDepartment data = new StudentDepartment();
            data.Student = s;
            data.Departments = db.Departments.GetAll();
            return View(data);

        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            
            //insert to db
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Insert(s);
                return RedirectToAction("Dashboard");
            }
            return View();

        }
        public ActionResult Edit(int id)
        {

            Database db = new Database();
            var s = db.Students.Get(id);

            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            //update to db
            Database db = new Database();
            db.Students.Update(s);
            return RedirectToAction("Dashboard");
        }


        public ActionResult Delete(int id)
        {
            
            Database db = new Database();
            db.Students.Delete(id);
            return RedirectToAction("Dashboard");

        }
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            if (ModelState.IsValid)
            {
                string connString = @"Server=DESKTOP-NI4ANO8;Database=StudentMS;Integrated Security=true;";
                SqlConnection conn1 = new SqlConnection(connString);
                string query = $"select * from Admins";
                SqlCommand cmd = new SqlCommand(query, conn1);
                conn1.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    string Name = reader.GetString(reader.GetOrdinal("Name"));
                    string UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    string Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (a.Password == Password && a.UserName == UserName)
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.Message = "invalid  Username or password.";
                        return View();

                    }
                }


            }
            return View();

        }
    }
}