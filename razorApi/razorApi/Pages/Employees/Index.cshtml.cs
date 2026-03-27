using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApi.Data;
using razorApi.Models;

namespace razorApi.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public List<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = _context.Employees.ToList();
        }
    }
}
