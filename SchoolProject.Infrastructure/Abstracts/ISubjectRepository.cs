using SchoolProject.Data.Entites;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface ISubjectRepository
    {
        Task<bool> SubjectNameArIsAlreadyExist(string Name);
        Task<bool> SubjectNameEnIsAlreadyExist(string Name);
        Task AddSubjectAsync(Subject subject);
        Task<IQueryable<Subject>> GetAllSubjects();
    }
}
