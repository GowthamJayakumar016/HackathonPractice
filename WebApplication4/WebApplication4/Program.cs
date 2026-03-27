var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("GLOBAL - Before");
    await next();
    Console.WriteLine("GLOBAL - After");
});

app.Map("/admin", adminApp =>
{
    adminApp.Use(async (context, next) =>
    {
        Console.WriteLine("ADMIN Middleware");
        await next();
    });

    adminApp.Run(async context =>
    {
        await context.Response.WriteAsync("Admin Final");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Default Final");
});

app.Run();
