using Newtonsoft.Json;
using ServiceAPI.Common.Types;

namespace ServiceAPI.Common.Mvc
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                HandleErrorAsync(context, exception);
            }
        }

        private static void HandleErrorAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = context.Request.ContentType;

            string body;
            if (exception is CommonException)
            {
                var e = exception as CommonException;
                context.Response.StatusCode = (int)e!.StatusCode;
                context.Response.Headers.Add("x-message", e.Message);
                //body = JsonConvert.SerializeObject(e.Message);
                // context.Response.WriteAsync(body);
            }
            else
            {
                body = JsonConvert.SerializeObject(exception.Message);
                context.Response.WriteAsync(body);
            }
        }
    }
}
