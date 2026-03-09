using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITI_Entities.Models
{
    public class Course
    {
        public int CrsID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Duration { get; set; }
        public ICollection<Department>? Departments { get; set; }
        public ICollection<Course_Student>? course_Students { get; set; }
    }
}
