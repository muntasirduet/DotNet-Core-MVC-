namespace CoreMVC.Middleware;


//custom middleware
public class MyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("before code for custom middleware\n");
        await next(context);
        await context.Response.WriteAsync("after code for custom middleware\n");

    }
}