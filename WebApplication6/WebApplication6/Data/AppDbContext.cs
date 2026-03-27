using Microsoft.EntityFrameworkCore;
using EmployeeModel.Models;

namespace WebApplication6.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees {  get; set; }
    }
}
