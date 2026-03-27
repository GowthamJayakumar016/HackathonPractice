using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Studentmanagement.Data;
using Studentmanagement.Models;
using StudentManagement.Shared.StudentRepository;
using System.Collections.Immutable;

namespace Studentmanagement.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            if (student == null) 
                throw new ArgumentNullException();

            var newstudent=_context.Students.Add(student).Entity;
            await _context.SaveChangesAsync();
            return newstudent;
        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if(student==null) return null;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async  Task<List<Student>> GetStudentsAsync()
        {
            var studentlist = await _context.Students.ToListAsync();

            return studentlist;

        }

        public async Task<Student> GetStudentsByIdAsync(int studentId)
        {
            var singlestudent = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (singlestudent == null) throw new ArgumentNullException();
            
            return singlestudent;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            if (student == null) return null;
            var newstudent = _context.Students.Update(student).Entity;
            await  _context.SaveChangesAsync();
            return newstudent;
        }
    }
}
