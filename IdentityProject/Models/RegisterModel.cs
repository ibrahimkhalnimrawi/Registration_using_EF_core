using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string UserName { get; set; }


    }
}
