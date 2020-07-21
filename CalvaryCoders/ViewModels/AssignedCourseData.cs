using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalvaryCoders.ViewModels
{
    public class AssignedCourseData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Duration { get; set; }
        public decimal Amount { get; set; }
        public bool Assigned { get; set; }
    }
}