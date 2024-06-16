using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.ExceptionFilter
{
    public class HandleExcepptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                Content = context.Exception.Message,
                StatusCode = 500
            };
        }
    }
}
