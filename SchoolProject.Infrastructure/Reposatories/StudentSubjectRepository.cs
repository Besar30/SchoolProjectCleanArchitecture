
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

        public async Task UpdateStudentSubjectAsync(StudentSubject studentSubject)
        {
            var studentSubjectOld = await _context.StudentSubjects.FirstAsync(x => x.StudID == studentSubject.StudID && x.SubID == studentSubject.SubID);
            studentSubjectOld.Grade=studentSubject.Grade;
            await _context.SaveChangesAsync();
        }
    }
}
