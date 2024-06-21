using Filters.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Filters.Identity
{
    public class IdentityDbContextClass1: IdentityDbContext<ApplicationUser,ApplicationRoles,Guid>
    {
        public IdentityDbContextClass1(DbContextOptions<IdentityDbContextClass1> options) : base(options) 
        {
           
        
        }
        public DbSet<IdentityClass> IdentityClasses { get; set; }
    }
}
