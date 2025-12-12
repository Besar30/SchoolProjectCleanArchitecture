using SchoolProject.Data.Entites;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface ISubjectRepository
    {
        public Task<bool> NameArIsExistExcludeSelf(string nameAr, int id);
        public Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id);
        Task<bool> SubjectNameArIsAlreadyExist(string Name);
        Task<bool> SubjectNameEnIsAlreadyExist(string Name);
        Task AddSubjectAsync(Subject subject);
        IQueryable<Subject> GetAllSubjects();
        Task<Subject> GetSubjectById(int Id);
        Task<Subject> GetSubjectByIdToUpdate(int Id);
        Task UpdateSubject(Subject Subject);
        Task DeleteSubjectAsync(Subject subject);
        Task<bool> SubjectIsExist(int Id);
        
    }
}
