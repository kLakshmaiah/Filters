using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Filters.Filters.AuthorizationFIlter
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("UserName"))
            {
                if (context?.HttpContext?.Request?.Headers["UserName"].FirstOrDefault()?.ToLower() != "laxman"){
                    context.Result = new BadRequestObjectResult("User is Not Authenticated User");
                }
            }else
            context.Result = new BadRequestObjectResult("User is Not Authenticated User");
        }
    }
}
