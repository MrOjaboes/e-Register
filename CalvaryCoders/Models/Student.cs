using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalvaryCoders.Models
{
    public enum MaritalStatus
    {
        Single, Married, Engaged, Divorced
    }
    public enum Gender
    {
        Male, Female
    }
    public class Student
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string passport { get; set; }
        public string streetName { get; set; }
        public short streetNumber { get; set; }
        public string town { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dob { get; set; }
        public int age { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public Gender? Gender { get; set; }
        public string contact { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        public string FullName { get { return lastName + " " + firstName; } }
        

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}