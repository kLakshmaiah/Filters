using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class AtrributeActionIsNotWOrking : IActionFilter, IOrderedFilter
    {
        private ILogger<AtrributeActionIsNotWOrking> logger;
        public int Order { get; set; }
        public string Name {  get; set; }
        public AtrributeActionIsNotWOrking(ILogger<AtrributeActionIsNotWOrking> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("{Filter} before this method is not working, try after 10 days Order {Order} Name is {Name}", nameof(AtrributeActionIsNotWOrking), Order,Name);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("{Filter}, After this method is not working, try after 10 days Order {Order} Name is {Name}", nameof(AtrributeActionIsNotWOrking), Order,Name);
        }
    }
}
