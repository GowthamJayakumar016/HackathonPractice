using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFApp.Data;
using RazorEFApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RazorEFApp.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Student> StudentList { get; set; } = new();

        public StudentsModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            StudentList = _context.Students.ToList();
            if (!_context.Students.Any())
            {
                _context.Students.Add(new Student { Name = "Aravind", Age = 20 });
                _context.SaveChanges();
            }

        }
    }
}
