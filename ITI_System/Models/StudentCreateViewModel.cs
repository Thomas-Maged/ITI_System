using ITI_Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_System.Models
{
    public class StudentCreateViewModel
    {
        public int ID { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage = "Invalid email format")]
        [Remote("CheckEmail", "Student")]
        public String Email { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public int DeptID { get; set; }

    }

}

