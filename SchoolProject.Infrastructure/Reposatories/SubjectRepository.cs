using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Reposatories
{
    public class SubjectRepository(ApplicationDBContext context) : ISubjectRepository
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<bool> SubjectNameArIsAlreadyExist(string Name)
        {
            return await _context.Subjects.AnyAsync(x=>x.SubjectNameAr==Name);   
        }
        public async Task<bool> SubjectNameEnIsAlreadyExist(string Name)
        {
            return await _context.Subjects.AnyAsync(x => x.SubjectNameEn == Name);
        }
        public async Task AddSubjectAsync(Subject subject)
        {
          _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Subject>> GetAllSubjects()
        {
            return  _context.Subjects.AsQueryable().AsNoTracking();
        }
    }
}
