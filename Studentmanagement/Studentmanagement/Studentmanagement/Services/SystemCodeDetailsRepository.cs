using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Services
{
    public class SystemCodeDetailsRepository : ISystemCodeDetailsRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public SystemCodeDetailsRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;


        }
        public async Task<SystemCodeDetail> AddAsync(SystemCodeDetail mod)
        {
            if (mod == null)
                throw new ArgumentNullException();
            using var context = _contextFactory.CreateDbContext();
            var data= context.SystemCodeDetails.Add(mod).Entity;
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<SystemCodeDetail> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var sycode = await context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (sycode == null) return null;
            context.SystemCodeDetails.Remove(sycode);
            await context.SaveChangesAsync();
            return sycode;
        }

        public async Task<List<SystemCodeDetail>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var codelist = await context.SystemCodeDetails.Include(c => c.SystemCode).ToListAsync();
            return codelist;
        }

        public async Task<List<SystemCodeDetail>> GetByCodeAsync(string code)
        {
            
            using var context = _contextFactory.CreateDbContext();

            var systemcodedetail = await context.SystemCodeDetails.Include(x => x.SystemCode).Where(x => x.SystemCode.Code == code).ToListAsync();

            return systemcodedetail;
        }

        public async Task<SystemCodeDetail> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var singlecode = await context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singlecode == null) throw new ArgumentNullException();

            return singlecode;
        }

        public async  Task<SystemCodeDetail> UpdateAsync(SystemCodeDetail mod)
        {
            using var context = _contextFactory.CreateDbContext();
            if (mod == null) return null;
            var newSystemcode = context.SystemCodeDetails.Update(mod).Entity;
            await context.SaveChangesAsync();
            return newSystemcode;
        }
    }
}
