using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class DevicePostActionFIlter : IActionFilter
    {
        private readonly ILogger<DevicePostActionFIlter> logger;

        public DevicePostActionFIlter(ILogger<DevicePostActionFIlter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)//after the action
        {
            
            logger.LogInformation("after action Method");
        }

        public void OnActionExecuting(ActionExecutingContext context)//before the action 
        {
            string? name = context.HttpContext.Items["name"] as string;
            if (string.IsNullOrEmpty(name))
            {
                context.Result = new BadRequestObjectResult("Name cannot be null or empty");
                return;
            }
            logger.LogInformation("Before action Method");
        }
    }
}
