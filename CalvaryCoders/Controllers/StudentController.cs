using CalvaryCoders.Models;
using CalvaryCoders.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CalvaryCoders.Controllers
{
    public class StudentController : Controller
    {
        private readonly CVCDbContext _db = new CVCDbContext();
        // GET: Student
        public ActionResult Index()
        {
            
            var students = _db.Students.Include(s => s.Courses).ToList();    

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult ApplicationPreview(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        // GET: Student/Create

        public string UploadImage(HttpPostedFileBase file)
        {
            var files = Request.Files;

            if (files != null)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // get a stream
                    var path = Path.Combine(Server.MapPath("~/Content/StudentImages"), file.FileName);
                    var dbPath = "Content/StudentImages/" + file.FileName;
                    file.SaveAs(path);
                    return dbPath;
                }
            }
            return null;
        }

        //Assigning Courses To Students
        private void PopulateAssignedCourseData(Student student)
        {
            var allCourses = _db.Courses;
            var studentCourses = new HashSet<int>(student.Courses.Select(c => c.Id));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {

                    Id = course.Id,
                    Name = course.Name,
                    Amount = course.Amount,
                    Duration = course.Duration,
                    Assigned = studentCourses.Contains(course.Id)
                });
            }
            ViewBag.Courses = viewModel;
        }
        public ActionResult SignUp()
        {
            var student = new Student();

            student.Courses = new List<Course>();
            PopulateAssignedCourseData(student);
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult SignUp(Student student, string[] selectedCourses, int id)
        {

           
                if (selectedCourses != null)
                {
                    student.Courses = new List<Course>();
                    foreach (var course in selectedCourses)
                    {
                        var courseToAdd = _db.Courses.Find(int.Parse(course));
                        student.Courses.Add(courseToAdd);
                    }
                }
                if (ModelState.IsValid)
                {
                    student.passport = UploadImage(Request.Files["model.passport"]);
                    var studentage = DateTime.Today.Year - student.dob.Value.Year;
                    student.age = studentage;
                student.DateAdded = DateTime.Now;
                    _db.Students.Add(student);
                    _db.SaveChanges();
                    return RedirectToAction("ApplicationPreview", new { Id = id });
                }
                PopulateAssignedCourseData(student);                
             
                return View();
             
        }

        
         
        }
    }

    
