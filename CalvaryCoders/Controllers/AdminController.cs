using CalvaryCoders.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalvaryCoders.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly CVCDbContext _db = new CVCDbContext();
        private readonly ApplicationDbContext _conn = new ApplicationDbContext();
        //Adding A New Role
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult CreateRole(IdentityRole identity)
        {

            _conn.Roles.Add(identity);
            _conn.SaveChanges();
            RedirectToAction("CreateRole");

            return View();
        }



        // GET: Registration
        
        public ViewResult Index()
        {
            var students = _db.Students.Include(s => s.Courses).OrderByDescending(s => s.Id);
            if (User.IsInRole("Admin"))
                return View("Admin",students);

            return View("Users", students);
        }

        public ActionResult StudentDetails(int id)
        {
            var student = _db.Students.FirstOrDefault(s=>s.Id==id);
            return View(student);
        }

        public ActionResult Courses()
        {
            var courses = _db.Courses.ToList();
            return View(courses);
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: Registration/Create

        // GET: Registration/Create
        [Authorize(Roles = "Admin")]
        public ActionResult NewCourse()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult NewCourse(Course course)
        {
            try
            {
                // TODO: Add insert logic here
                course.DateAdded = DateTime.Now;
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
