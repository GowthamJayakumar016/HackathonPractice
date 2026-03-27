using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Services
{
    public class ParentRepository : IParentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ParentRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Parent> AddAsync(Parent mod)
        {
            if (mod == null)
                throw new ArgumentNullException();
            using var context = _contextFactory.CreateDbContext();
            var newparent = context.parents.Add(mod).Entity;
            await context.SaveChangesAsync();
            return newparent;
        }

        public async Task<Parent> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var data = await context.parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;
            context.parents.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async  Task<List<Parent>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var parentlist = await context.parents.Include(p => p.Gender).Include(x=>x.Student).ToListAsync();
            return parentlist;
        }

        public async  Task<Parent> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var singleparent = await context.parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singleparent == null) throw new ArgumentNullException();

            return singleparent;
        }

        public async Task<Parent> UpdateAsync(Parent mod)
        {
            using var context = _contextFactory.CreateDbContext();
            if (mod == null) return null;
            var updatedparent = context.parents.Update(mod).Entity;
            await context.SaveChangesAsync();
            return updatedparent;
        }
    }
}
