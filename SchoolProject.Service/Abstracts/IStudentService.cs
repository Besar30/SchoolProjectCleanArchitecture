using SchoolProject.Data.Entites;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<Result<IQueryable<Student>>> GetStudentsListAsync();
        public Task<Result<Student>> GetStudentById(int Id);
        public Task<Result<string>> AddStudentAsync(Student student);
        public Task<Result<string>> UpdateStudentAsync(Student student);
        public Task<Result> NameIsFoundExcludeSelf(string name, int Id);
        public Task <Result<string>> DeleteStudent(int Id);
        public Task<Result> ToggleStatusStudentAsync(int Id);

    }
}
