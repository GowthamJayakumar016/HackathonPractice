using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorwebapp.Models;
using razorwebapp;

namespace razorwebapp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; } = new List<Student>();


        public void OnGet()
        {
            Students = _context.Students.ToList(); // LINQ + EF
        }
        public void OnGetAdd()
        {
            Student s = new Student
            {
                Name = "Aravind",
                Age = 20
            };

            _context.Students.Add(s);
            _context.SaveChanges();
        }

    }
}
