using System.Diagnostics;

namespace LibMan.Web;

public class CalculatRequestTimeMiddleware
{
    private readonly RequestDelegate _next;

    public CalculatRequestTimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();
        File.AppendAllText("timetaken.txt", $" {DateTime.Now} : {context.Request.Path} {context.Request.Method} {stopwatch.ElapsedMilliseconds}ms\n");
    }
}

public static class CalculatRequestTimeMiddlewareExtensions
{
    public static IApplicationBuilder UseCalculatRequestTime(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CalculatRequestTimeMiddleware>();
    }
    
}