using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITI_Entities.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
