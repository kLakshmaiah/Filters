using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate Next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string authorizevalue = httpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizevalue))
            {
                if (authorizevalue != "laxman")
                {
                    var result = new
                    {
                        StatusCode=500,
                        Message = "Invalida User"

                    };
                    httpContext.Response.WriteAsJsonAsync(result);
                }
                else
                {
                    Next(httpContext);
                }
            }else
            httpContext.Response.WriteAsJsonAsync("Invalid UserName");
           
        }
    }
}
