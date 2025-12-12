using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Reposatories
{
    public class StudentRepository(ApplicationDBContext context) : IStudentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<IQueryable<Student>> GetStudentsListAsync()
        {
            return _context.Students
                   .Include(x => x.Department)
                   .AsNoTracking();
                  
        }
        public async Task<bool> StudentIsExist(int Id)
        {
           return await _context.Students.AnyAsync(x=>x.StudentID==Id);
        }
        public async Task<Student?> GetStudentById(int Id)
        {
            var student = await _context.Students.Include(x=>x.Department).FirstOrDefaultAsync(x => x.StudentID == Id);
            return student;
        }

        public async Task AddStudentAsync(Student student)
        {
             _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckStudentFound(string Name)
        {
            return await _context.Students.AnyAsync(x=>x.NameAr == Name);
        }

        public async Task EditStudentAsync(Student student)
        {
            //_context.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckStudentFound(string name, int Id)
        {
            return await _context.Students.AnyAsync(x => x.NameAr == name && x.StudentID != Id);
        }

        public async Task DeleteStudentAsync(int Id)
        {
           var student = await _context.Students.FirstAsync(x=>x.StudentID==Id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task ToggleStatusStudentAsync(int Id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == Id);
            student.IsDisabled =!student.IsDisabled;
            await _context.SaveChangesAsync();
        }

  
    }
}
