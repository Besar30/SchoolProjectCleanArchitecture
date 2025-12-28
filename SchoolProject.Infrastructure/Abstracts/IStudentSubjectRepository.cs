using SchoolProject.Data.Entites;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentSubjectRepository
    {
        public Task<bool> StudentSubjectIsExistAlready(int StudentId, int subjectId);
        public Task AddStudentSubjectAsync(StudentSubject studentSubject);
        public Task UpdateStudentSubjectAsync(StudentSubject studentSubject);
    }
}
