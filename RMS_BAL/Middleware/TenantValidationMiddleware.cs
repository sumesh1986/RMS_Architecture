using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;

public class TenantValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TenantValidationMiddleware> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TenantValidationMiddleware(
        RequestDelegate next,
        ILogger<TenantValidationMiddleware> logger,
        IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
        var path = context.Request.Path.Value?.ToLowerInvariant();

        var allowedPaths = new[]
        {
            "/", "/api/release", "/home/login",
            "/home/assets/libs/apexcharts/apexcharts.min.js",
            "/home/assets/js/pages/dashboard.init.js",
            "/home/assets/images/product/img-7.png", "/home/assets/images/product/img-4.png",
            "/home/assets/images/users/avatar-4.jpg",
            "/css", "/js", "/images",
            "/fonts/materialdesignicons-webfont.woff",
            "/fonts/materialdesignicons-webfont.ttf",
            "/.well-known/appspecific/com.chrome.devtools.json"
        };

        // Skip validation for allowed static/public paths
        if (allowedPaths.Contains(path, StringComparer.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

        // Validate login attempt
        if (path == "/api/login" || path == "/api/verifyotp")
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<OtherService>();

            context.Request.EnableBuffering();
            var form = await context.Request.ReadFormAsync();
            context.Request.Body.Position = 0;

            var username = form["username"].ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var user = await db.UserMaster
                    .Where(u => u.UserName == username)
                    .OrderByDescending(u => u.CreatedOn)
                    .FirstOrDefaultAsync();

                if (user?.IsLockedOut == true)
                {
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("{\"message\":\"Account is locked. Please contact administrator to unblock.\"}");
                    return;
                }
            }

            await _next(context);
            return;
        }

        // Enforce session for protected APIs
        var tenantId = tenantService.GetCurrentTenantId();
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            if (!path.StartsWith("/api"))
            {
                context.Response.Redirect("/Home/Login?sessionExpired=true");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\":\"Session expired. Please log in again.\"}");
            }
            return;
        }

        // Proceed to next middleware
        await _next(context);
    }
}
