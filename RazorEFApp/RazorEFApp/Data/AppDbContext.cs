using Microsoft.EntityFrameworkCore;
using RazorEFApp.Models;

namespace RazorEFApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}