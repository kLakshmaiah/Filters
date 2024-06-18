using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.ServiceFilter.Action
{
    public class DeviceActionIsNotWorkingServiceFilter : IActionFilter
    {
        private ILogger<DeviceActionIsNotWorkingServiceFilter> logger;
        private int? Order;
        public DeviceActionIsNotWorkingServiceFilter(ILogger<DeviceActionIsNotWorkingServiceFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("{Filter} before this method is not working, try after 10 days", nameof(DeviceActionIsNotWorkingServiceFilter));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("{Filter}, After this method is not working, try after 10 days", nameof(DeviceActionIsNotWorkingServiceFilter));
        }
    }
}
