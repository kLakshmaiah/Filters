using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class DevicePostActionFIlter : IActionFilter
    {
        private readonly ILogger<DevicePostActionFIlter> logger;
        private int? Order { get; }
        public DevicePostActionFIlter(ILogger<DevicePostActionFIlter> logger, int? order)
        {
            this.logger = logger;
            Order = order;
        }
        public void OnActionExecuted(ActionExecutedContext context)//after the action
        {
            
            logger.LogInformation("{filter}, after action Method Order {Order}",nameof(DevicePostActionFIlter),Order);
        }

        public void OnActionExecuting(ActionExecutingContext context)//before the action 
        {
            //string? name = context.HttpContext.Items["name"] as string;
            //if (string.IsNullOrEmpty(name))
            //{
            //    context.Result = new BadRequestObjectResult($"Name cannot be null or empty Order {Order}");
            //    return;
            //}
            logger.LogInformation("{filter}, Before action Method {Order}",nameof(DevicePostActionFIlter),Order);
        }
    }
}
