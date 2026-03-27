using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Studentmanagement.Client.Services;
using StudentManagement.Shared.StudentRepository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddScoped<IStudentRepository, StudentService>();
builder.Services.AddScoped<ICountryRepository, CountryService>();
builder.Services.AddScoped<ISystemCodeRepository,SystemCodeService>();
builder.Services.AddScoped<ISystemCodeDetailsRepository,SystemCodeDetailsService>();
builder.Services.AddScoped<IParentRepository,ParentService>();
builder.Services.AddScoped<ITeacherRepository,TeacherService>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
