using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Filters.Filters.AuthorizationFIlter
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        private string UserName { get; set; }
        public AuthorizeFilter(string userName) 
        {
            UserName = userName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? headervalue = context?.HttpContext?.Request?.Headers["UserName"].FirstOrDefault()?.ToLower();
            if (!string.IsNullOrEmpty(headervalue) || !string.IsNullOrEmpty(UserName))
            {
                if ( UserName!="laxman"){
                    context.Result = new BadRequestObjectResult("User is Not Authenticated User");
                }
            }
        }
    }
}
