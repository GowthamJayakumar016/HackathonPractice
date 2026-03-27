using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studentmanagement.Models;
using StudentManagement.Shared.Models;
using System.Reflection.Emit;

namespace Studentmanagement.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<Teacher> teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parent>()
       .HasOne(p => p.Gender)
       .WithMany()
       .HasForeignKey(p => p.GenderId)
       .OnDelete(DeleteBehavior.Restrict); // OR NoAction

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.ParentType)
                .WithMany()
                .HasForeignKey(p => p.ParentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
