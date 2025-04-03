namespace LibMan.Web;
public class LogUserRequestMiddleware
{
    private readonly RequestDelegate _next;

    public LogUserRequestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //Get the IP address of the user
        var ipAddress = context.Connection.RemoteIpAddress;
        var userAgent = context.Request.Headers["User-Agent"];
        
    
        File.AppendAllText("request.txt", $" {DateTime.Now} : {ipAddress} {userAgent} {context.Request.Path} {context.Request.Method} {context.Request.QueryString} {context.Request.Body}\n");
      
        //Log the request to the console
        await _next(context);
        
    }
    
}

public static class LogUserRequestMiddlewareExtensions
{
    public static IApplicationBuilder UseLogUserRequest(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogUserRequestMiddleware>();
    }
}