using System.Diagnostics;
using System.Net;
using System.Text.Json;
using WebAPI.Services;

namespace WebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]   HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Log(message);

                await _next(context);
                watch.Stop();

                message = "[Response]  HTTP " + context.Request.Method + " - " + context.Request.Path + " - " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + " ms";
                _loggerService.Log(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
            

        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error" + ex.Message + " in " + watch.ElapsedMilliseconds;
            _loggerService.Log(message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //var result = JsonSerializer.Serialize(new { Error = ex.Message });
            return context.Response.WriteAsJsonAsync(new { Error = ex.Message });
        }
    }
}
