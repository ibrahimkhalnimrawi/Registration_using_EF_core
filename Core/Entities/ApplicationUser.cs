using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
