using Microsoft.AspNetCore.Identity;

namespace Filters.Models
{
    public class ApplicationUser:IdentityUser<Guid>//AspNetUsers in the Databases
    {
        public string? Password { get; set; }
    }
}
