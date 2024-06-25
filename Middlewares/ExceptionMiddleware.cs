
namespace Filters.Middlewares
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
        }
        //
    }
}
