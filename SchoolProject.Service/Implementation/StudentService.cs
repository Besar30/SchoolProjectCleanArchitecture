using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
namespace SchoolProject.Service.Implementation
{
    public class StudentService(IStudentRepository studentRepository,IDepartmentRepository departmentRepository) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public async Task<Result<IQueryable<Student>>> GetStudentsListAsync()
        {
            var students= await _studentRepository.GetStudentsListAsync();
            return Result.Success(students);
        }
        public async Task<Result<Student>> GetStudentById(int Id)
        {
           var student= await _studentRepository.GetStudentById(Id);
            if (student == null)
                return Result.Failure<Student>(StudentErrors.StudentNotFound);
            return Result.Success(student);
        }

        public async Task<Result<string>> AddStudentAsync(Student student)
        {
           //check if student name found ?
            var NameStudentIsFound= await _studentRepository.CheckStudentFound(student.NameAr);
            if (NameStudentIsFound ==true)
                return Result.Failure<string>(StudentErrors.NameStudentDuplicated);
            var DepartmentIsFound = await _departmentRepository.DepartmentISFound(student.DID.Value);
            if (!DepartmentIsFound)
                return Result.Failure<string>(DepartmentErrors.DepartmentNotFound);
            
            await _studentRepository.AddStudentAsync(student);
            return Result.Success("Student Added");
        }

        public async Task<Result<string>> UpdateStudentAsync(Student student)
        {
            await _studentRepository.EditStudentAsync(student);
            return Result.Success("Student Updited");
        }

        public async Task<Result> NameIsFoundExcludeSelf(string name, int Id)
        {
           var result =await _studentRepository.CheckStudentFound(name, Id);
            if (result == true)
                return Result.Failure(StudentErrors.NameStudentDuplicated);
            return Result.Success();
        }

        public async Task<Result<string>> DeleteStudent(int Id)
        {
           await _studentRepository.DeleteStudentAsync(Id);
            return Result.Success("Student Deleted");
        }

        public async Task<Result> ToggleStatusStudentAsync(int Id)
        {
            var student = await _studentRepository.StudentIsExist(Id);
            if (!student)
                return Result.Failure(StudentErrors.StudentNotFound);
            await _studentRepository.ToggleStatusStudentAsync(Id);
            return Result.Success();
        }
    }
}
