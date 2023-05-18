using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lesson1_login
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandleError
{
    private readonly RequestDelegate _next;
        private ILogger<HandleError> _logger;
    public HandleError(RequestDelegate next, ILogger<HandleError> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception e)
        {
            _logger.LogError($"cought in middlewear {e.Message} ");
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsync("Internal server error");
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandleError>();
    }
}
}
