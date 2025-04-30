using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RMS_BAL.Services.Interfaces;
using RMS_Models.Models.ServiceModels;
using System.Text.Json;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace RMS_BAL.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            
            
            
            
            {
                var routeData = context.GetRouteData();
                var controller = routeData.Values["controller"]?.ToString();
                var action = routeData.Values["action"]?.ToString();

                _logger.LogError(ex, $"Unhandled exception in {controller}/{action}");

                using (var scope = _scopeFactory.CreateScope())
                {
                    var exceptionService = scope.ServiceProvider.GetRequiredService<IExceptionHandlingService>();
                    var st = new StackTrace(ex, true); // true to get file info
                    var frame = st.GetFrames()?.FirstOrDefault(f => f.GetFileLineNumber() > 0);
                    var lineNumber = frame?.GetFileLineNumber();
                    var fileName = frame?.GetFileName();

                    var log = new ErrorLog
                    {
                        Message = ex.Message,
                        StackTrace = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None).FirstOrDefault(),
                        Source = ex.Source,
                        Path = context.Request.Path,
                        Controller = controller,
                        Action = action,
                        CreatedOn = DateTime.UtcNow,
                        LineNumber = lineNumber,
                        FileName = fileName,
                        RegistrationId = "null",
                        User = "null"
                    };


                    await exceptionService.LogError(log);
                }

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new { message = "An unexpected error occurred. Please contact support." };
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
