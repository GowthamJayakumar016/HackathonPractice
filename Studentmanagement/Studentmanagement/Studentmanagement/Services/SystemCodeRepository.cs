using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Services
{
    public class SystemCodeRepository : ISystemCodeRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public SystemCodeRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;


        }

        public async Task<SystemCode> AddAsync(SystemCode mod)
        {
            if (mod == null)
                throw new ArgumentNullException();
            using var context = _contextFactory.CreateDbContext();
            var newcode = context.SystemCodes.Add(mod).Entity;
            await context.SaveChangesAsync();
            return newcode;
        }

        public async Task<SystemCode> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var systemcode = await context.SystemCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (systemcode == null) return null;
            context.SystemCodes.Remove(systemcode);
            await context.SaveChangesAsync();
            return systemcode;
        }

        public async  Task<List<SystemCode>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var codelist = await context.SystemCodes.ToListAsync();
            return codelist;
        }

        public async Task<SystemCode> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var singlecode = await context.SystemCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singlecode == null) throw new ArgumentNullException();

            return singlecode;
        }

        public async Task<SystemCode> UpdateAsync(SystemCode mod)
        {
            using var context = _contextFactory.CreateDbContext();
            if (mod == null) return null;
            var newcode= context.SystemCodes.Update(mod).Entity;
            await context.SaveChangesAsync();
            return newcode;
        }
    }
}
