using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITI_Entities.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
