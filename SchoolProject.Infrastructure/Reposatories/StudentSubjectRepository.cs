
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Reposatories
{
    public class StudentSubjectRepository (ApplicationDBContext context) : IStudentSubjectRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task AddStudentSubjectAsync(StudentSubject studentSubject)
        {
            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> StudentSubjectIsExistAlready(int StudentId, int subjectId)
        {
            return await _context.StudentSubjects.AnyAsync(x=>x.StudID==StudentId && x.SubID==subjectId);
        }
    }
}
