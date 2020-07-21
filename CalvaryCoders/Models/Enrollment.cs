using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryCoders.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public Student student { get; set; }
        public int StudentId { get; set; }

        public Course course { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}