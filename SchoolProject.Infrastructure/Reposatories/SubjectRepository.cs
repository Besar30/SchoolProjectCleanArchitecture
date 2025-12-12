using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using static Azure.Core.HttpHeader;

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

        public async Task<bool> NameArIsExistExcludeSelf(string nameAr, int id)
        {
           return await _context.Subjects.AnyAsync(x=>x.SubjectNameAr == nameAr&&x.SubID!=id);
        }

        public async Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id)
        {
            return await _context.Subjects.AnyAsync(x => x.SubjectNameEn == nameEn && x.SubID != id);
        }
        public async Task AddSubjectAsync(Subject subject)
        {
          _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            return  _context.Subjects.AsNoTracking();
        }

        public async Task<Subject> GetSubjectById(int Id)
        {
           return await _context.Subjects
                                        .Include(x=>x.StudentsSubjects).ThenInclude(x=>x.Student)
                                        .Include(s=>s.InsSubjects).ThenInclude(x=>x.instractor)
                                        .Include(x=>x.DepartmetsSubjects).ThenInclude(x=>x.Department)
                                        .FirstOrDefaultAsync(x=>x.SubID==Id);
        }

        public async Task<Subject> GetSubjectByIdToUpdate(int Id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x=>x.SubID == Id);
        }

        public async Task UpdateSubject(Subject Subject)
        {
           var oldSubject= await _context.Subjects.FirstAsync(x=>x.SubID==Subject.SubID);
            oldSubject.SubjectNameAr=Subject.SubjectNameAr;
            oldSubject.SubjectNameEn=Subject.SubjectNameEn;
            oldSubject.Period=Subject.Period;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
           
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SubjectIsExist(int Id)
        {
            return await _context.Subjects.AnyAsync(x=>x.SubID== Id);
        }
    }
}
