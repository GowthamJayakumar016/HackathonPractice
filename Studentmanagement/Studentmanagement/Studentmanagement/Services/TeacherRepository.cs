using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace Studentmanagement.Services
{
    public class TeacherRepository : ITeacherRepository

    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public TeacherRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Teacher> AddAsync(Teacher mod)
        {
            if (mod == null)
                throw new ArgumentNullException();
            using var context = _contextFactory.CreateDbContext();
            var newteacher = context.teachers.Add(mod).Entity;
            await context.SaveChangesAsync();
            return newteacher;
        }

        public async Task<Teacher> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var data = await context.teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;
            context.teachers.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var teacherlist = await context.teachers
                .Include(x => x.Designation)
                .Include(x => x.Gender)
                .ToListAsync();
            return teacherlist;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var singleteacher = await context.teachers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singleteacher == null) throw new ArgumentNullException();

            return singleteacher;
        }

        public async Task<Teacher> UpdateAsync(Teacher mod)
        {
            using var context = _contextFactory.CreateDbContext();
            if (mod == null) return null;
            var updatedteacher = context.teachers.Update(mod).Entity;
            await context.SaveChangesAsync();
            return updatedteacher;
        }
    }
}
