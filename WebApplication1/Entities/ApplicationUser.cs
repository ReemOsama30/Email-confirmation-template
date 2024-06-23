using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}