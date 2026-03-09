using ITI_Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI_System.Models
{
    //View Model for registeration of new users y admin with roles
    public class ResgisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public List<string> Roles { get; set; } = new List<String>();
    }
}
