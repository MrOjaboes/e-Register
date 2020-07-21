using CalvaryCoders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryCoders.ViewModels
{
    public class StudentindexData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}