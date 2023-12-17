using System.Diagnostics.CodeAnalysis;
using CoreMVC.Middleware;

var builder = WebApplication.CreateBuilder(args);


//Register Customs Middleware as a service
builder.Services.AddTransient<MyMiddleware>();


var app = builder.Build();


//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Well come to first middleware\n");
    await next(context);
});
//middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Well come to Second middleware\n");
    await next(context);
});
//middleware 3(Custom Middleware)
app.UseMiddleware<MyMiddleware>();

//middleware 4
app.Run(async (context) =>
{
    await context.Response.WriteAsync("This is the App RUN  function(Middleware)/n");
    
} );

app.Run();