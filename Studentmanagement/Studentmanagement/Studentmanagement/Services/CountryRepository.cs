using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using Studentmanagement.Models;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public CountryRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Country> AddAsync(Country mod)
        {
            if (mod == null)
                throw new ArgumentNullException();
            using var context = _contextFactory.CreateDbContext();
            var newcountry = context.Countries.Add(mod).Entity;
            await context.SaveChangesAsync();
            return newcountry;
        }

        public async Task<Country> DeleteAsync(int Id)
        {
            using var context = _contextFactory.CreateDbContext();
            var data = await context.Countries.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (data == null) return null;
            context.Countries.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<List<Country>> GetAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var countrylist = await context.Countries.ToListAsync();
            //await _context.SaveChangesAsync();
            return countrylist;
        }

        public async Task<Country> GetByIdAsync(int Id)
        {
            using var context = _contextFactory.CreateDbContext();
            var singlecountry = await context.Countries.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (singlecountry== null) throw new ArgumentNullException();

            return singlecountry;
        }

        public async  Task<Country> UpdateAsync(Country mod)
        {
            using var context = _contextFactory.CreateDbContext();
            if (mod == null) return null;
            var newcountry = context.Countries.Update(mod).Entity;
            await context.SaveChangesAsync();
            return newcountry;
        }
    }
}
