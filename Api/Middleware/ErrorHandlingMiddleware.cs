using Data;
using Data.Exeptions;

namespace Api.Middleware
{
    
    
        public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILog _logger;
        public ErrorHandlingMiddleware(ILog logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundExeption)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundExeption.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                _logger.Error(ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");

            }
        }
    }
}


