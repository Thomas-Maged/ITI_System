using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITI_Entities.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public String Email { get; set; }

        public int? Age { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public Department Department { get; set; }
        public ICollection<Course_Student> course_Students { get; set; }

    }
}
