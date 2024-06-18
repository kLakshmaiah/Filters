using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.ServiceFilter.Action
{
    public class DevicePostActionFIlterServicFilter : IActionFilter
    {
        private readonly ILogger<DevicePostActionFIlterServicFilter> logger;
        private int? Order { get; }
        public DevicePostActionFIlterServicFilter(ILogger<DevicePostActionFIlterServicFilter> logger, int? order)
        {
            this.logger = logger;
            Order = order;
        }
        public void OnActionExecuted(ActionExecutedContext context)//after the action
        {

            logger.LogInformation("{filter}, after action Method Order {Order}", nameof(DevicePostActionFIlterServicFilter), Order);
        }

        public void OnActionExecuting(ActionExecutingContext context)//before the action 
        {
            string? name = context.HttpContext.Items["name"] as string;
            if (string.IsNullOrEmpty(name))
            {
                context.Result = new BadRequestObjectResult($"Name cannot be null or empty Order {Order}");
                return;
            }
            logger.LogInformation("{filter}, Before action Method {Order}", nameof(DevicePostActionFIlterServicFilter), Order);
        }
    }
}
