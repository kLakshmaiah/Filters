using AutoMapper;
using Filters.DTO;
using Filters.Identity;
using Filters.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Filters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityDbCOntroller : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManager;//data inserted into the AspNetUsers
        public RoleManager<ApplicationRoles> RoleManager { get; }//data inserted into the AspNetRoles //signingManager,signoutManager,
        public IMapper Mapper { get; }
        public IdentityDbContextClass1 Db { get; }

        public IdentityDbCOntroller(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRoles> roleManager,IMapper mapper, IdentityDbContextClass1 identityDbContext)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            Mapper = mapper;
            Db = identityDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //List<ApplicationUser> applicationUsers = UserManager.Users.ToList();
            //List<UserDetails> userDetails = Mapper.Map<List<UserDetails>>(applicationUsers);
            List<UserDetails> userDetails=     (from user in Db.Users
                         join Usersroles in Db.UserRoles on user.Id equals Usersroles.UserId
                         join roles in Db.Roles on Usersroles.RoleId equals roles.Id
                         join Claim in Db.RoleClaims on roles.Id equals Claim.RoleId
                         select new UserDetails
                         {
                             Email = user.Email,
                             UserName = user.UserName,
                             PhoneNumber = user.PhoneNumber,
                             RoleDescription = Claim.ClaimValue,
                             UserRole = roles.Name,
                             Password=user.Password
                         }).ToList();

            return Ok(userDetails);
        }
        [HttpPost]
        public async Task<IActionResult> InsertRoleAndUsers(UserDetails userDetails)
        {
           
            //ApplicationUser applicationUser = new ApplicationUser { UserName = userDetails.UserName, Email = userDetails.Email, PhoneNumber = userDetails.PhoneNumber };
            ApplicationUser applicationUser=Mapper.Map<ApplicationUser>(userDetails);
            IdentityResult result = await UserManager.CreateAsync(applicationUser, userDetails.Password);//create the user
            if (result.Succeeded)
            {
                List<Claim> claims = new List<Claim>()
                    {
                             new Claim("userPassword", userDetails.Password),
                             new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber)
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

        [HttpGet("{usernane}")]
        public async Task<IActionResult> Update(string usernane)
        {
            ApplicationUser user=await Db.Users.AsNoTracking().FirstOrDefaultAsync(s=>s.UserName==usernane);
            user.UserName=user.UserName.ToUpper();
            Db.Update(user);
           return Ok(await Db.SaveChangesAsync());
        }
    }
}
