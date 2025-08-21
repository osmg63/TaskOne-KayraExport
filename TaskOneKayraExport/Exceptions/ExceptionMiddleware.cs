
namespace TaskOneKayraExport.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {

                await next(context);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            int statusCode= ExceptionStatusCodeMapper.GetStatusCode(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode=statusCode;

            List<string> errors = new()
            {
                ex.Message,
                ex.InnerException?.ToString()
            };

                return context.Response.WriteAsync(new ExceptionModel
                {
                    Errors = errors,
                    StatusCode = statusCode

                }.ToString());

            
        }
             
    }
}