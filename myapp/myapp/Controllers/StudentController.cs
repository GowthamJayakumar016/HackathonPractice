using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        Student s = new Student()
        {
            Id = 1,
            Name = "Aravind",
            Age = 20
        };

        return View(s);
    }
}
