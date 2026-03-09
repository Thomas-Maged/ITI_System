using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Models
{
    public class Course_Student
    {
        public int CrsID { get; set; }
        public Course Course { get; set; }
        public int StdID { get; set; }
        public Student Student { get; set; }
        public int? Grade { get; set; }
    }
}
