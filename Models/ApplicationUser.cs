using Microsoft.AspNetCore.Identity;

namespace Filters.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? Password { get; set; }
    }
}
