using System.Net;
using System.Text.Json;

namespace ShopEZ_E_Commerce.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            // DIFFERENT STATUS BASED ON ERROR TYPE
            int statusCode = ex switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,        // 400
                KeyNotFoundException => (int)HttpStatusCode.NotFound,       // 404
                InvalidOperationException => (int)HttpStatusCode.BadRequest,// 400
                _ => (int)HttpStatusCode.InternalServerError                // 500
            };

            context.Response.StatusCode = statusCode;

            var result = new
            {
                success = false,
                status = statusCode,
                message = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
