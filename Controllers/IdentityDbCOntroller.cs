using Filters.Identity;
using Filters.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Filters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityDbCOntroller : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManager;//data inserted into the AspNetUsers
        public RoleManager<ApplicationRoles> RoleManager { get; }//data inserted into the AspNetRoles

        public IdentityDbCOntroller(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRoles> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> Register(string username, string password)
        {
            ApplicationUser applicationUser = new ApplicationUser { UserName = username };
            IdentityResult result = await UserManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                return Ok("user is created success fully");
            }
            return Ok(new object[] { username, password });
        }
        [HttpPost]
        public async Task<IActionResult> InsertRoleAndUsers(UserDetails userDetails)
        {
           
            ApplicationUser applicationUser = new ApplicationUser { UserName = userDetails.UserName, Email = userDetails.Email, PhoneNumber = userDetails.MobilNumber };
            IdentityResult result = await UserManager.CreateAsync(applicationUser, userDetails.Password);//create the user
            if (result.Succeeded)
            {
                List<Claim> claims = new List<Claim>()
                    {
                             new Claim("userPassword", userDetails.Password),
                             new Claim(ClaimTypes.MobilePhone, userDetails.MobilNumber)
                    };

                IdentityResult identityResult = await UserManager.AddClaimsAsync(applicationUser, claims);//Data inserted into AspNetUserClaims

                if (identityResult.Succeeded)
                {
                    ApplicationRoles applicationRoles = new ApplicationRoles { Name = userDetails.UserRole };
                    await RoleManager.CreateAsync(applicationRoles);
                    await UserManager.AddToRoleAsync(applicationUser, userDetails.UserRole);//data inserted into the AspnetUserRoles
                    Claim roleClaim = new Claim("Role description", userDetails.RoleDescription);
                    await RoleManager.AddClaimAsync(applicationRoles, roleClaim);
                    return Ok("success fully create the user");
                }

            }
            return BadRequest(result.Errors.FirstOrDefault() );
        }
    }
}
