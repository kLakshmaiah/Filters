using Filters.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityDbCOntroller:ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityDbCOntroller(UserManager<ApplicationUser>  userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register(string username, string password)
        {
            ApplicationUser applicationUser=new ApplicationUser { UserName = username};
           IdentityResult result=  await   userManager.CreateAsync(applicationUser,password);
            if(result.Succeeded)
            {
                return Ok("user is created success fully");
            }
            return Ok(new object[] { username, password }) ;
        }
    }
}
