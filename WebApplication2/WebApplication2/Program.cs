var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
string p = context.Request.Path;
string m = context.Request.Method;
return $"Path{p}Method{m}";
    context.Response.StatusCode = 404;
}
);

app.Run();
