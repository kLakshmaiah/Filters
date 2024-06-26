﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.Action
{
    public class DeviceActionIsNotWorking : IActionFilter
    {
        private ILogger<DeviceActionIsNotWorking> logger;
        public int? Order;
        public DeviceActionIsNotWorking(ILogger<DeviceActionIsNotWorking> logger, int? order)
        {
            this.logger = logger;
            Order = order;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("{Filter} before this method is not working, try after 10 days Order {Order}", nameof(DeviceActionIsNotWorking), Order);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("{Filter}, After this method is not working, try after 10 days Order {Order}", nameof(DeviceActionIsNotWorking), Order);
        }
    }
}
