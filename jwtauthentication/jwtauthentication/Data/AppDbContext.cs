using Microsoft.EntityFrameworkCore;
using jwtauthentication.Models;

namespace jwtauthentication.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
