using Filters.Filters.Action;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{/// <summary>
///   It allows DI,Parameters,Attribute 
/// </summary>
    public class AttributeIFilterFactory : Attribute, IFilterFactory
    {
        public bool IsReusable => false;//pending.
        public int Order { get; set; }
        public string Name { get; set; }
        public AttributeIFilterFactory(int order,string name)
        {
            Order= order;
            Name= name;
        }
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var result=  serviceProvider.GetRequiredService<AtrributeActionIsNotWOrking>();//must and should implement the AtrributeActionIsNotWOrking is Registered as service.
            result.Order=Order;
            result.Name=Name;
            return result;
        }
    }
}
