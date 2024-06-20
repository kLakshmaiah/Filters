using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.AttributeExample
{
    //ActionFilterAttribute,ExceptionFilterAttribute,ResultFilterAttribute
    public class DeviceActionIsNotWorking : ActionFilterAttribute
    {
        //private ILogger<DeviceActionIsNotWorking> logger;  dependency injection is not allowed
        private int Order;
        public DeviceActionIsNotWorking(int order)
        {
            Order = order;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // logger.LogInformation("{Filter} before this method is not working, try after 10 days Order {Order}", nameof(DeviceActionIsNotWorking), Order);
            Console.WriteLine("{0} before this method is not working, try after 10 days Order {1}", nameof(DeviceActionIsNotWorking), Order);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //logger.LogInformation("{Filter}, After this method is not working, try after 10 days Order {Order}", nameof(DeviceActionIsNotWorking), Order);
            Console.WriteLine(string.Format("{0} before this method is not working, try after 10 days Order {1}", nameof(DeviceActionIsNotWorking), Order));
        }
    }
}
