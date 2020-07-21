using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryCoders.Models
{
    
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Duration { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}