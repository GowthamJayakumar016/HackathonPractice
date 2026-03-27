using Microsoft.EntityFrameworkCore;
using GroceryShopApp.Models;

namespace GroceryShopApp.Data
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
