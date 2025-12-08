using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Procedures;
using SchoolProject.Data.Entites.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;

namespace SchoolProject.Service.Implementation
{
    public class DepartmentService(IDepartmentRepository departmentRepository,IInstractorRepository instractorRepository,IViewRepository<ViewDepartment> viewRepository,IDepartmentStudentCountProcRepository departmentStudentCountProcRepository) : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IInstractorRepository _instractorRepository = instractorRepository;
        private readonly IViewRepository<ViewDepartment> _viewRepository = viewRepository;
        private readonly IDepartmentStudentCountProcRepository _departmentStudentCountProcRepository = departmentStudentCountProcRepository;
        public async Task<Result> AddDepartmentAsync(Department department)
        {
            var NameArIsExist = await _departmentRepository.NameArDepartmentIsExist(department.DNameAr!);
            if (NameArIsExist)
                return Result.Failure(DepartmentErrors.DepartmentArNameIsExist);
            var NameEnIsExist= await _departmentRepository.NameEnDepartmentIsExist(department.DNameEn!);
            if(NameEnIsExist)
                return Result.Failure(DepartmentErrors.DepartmentEnNameIsExist);
            if (department.InsManger != null)
            {
                var instractorIsExist = await _instractorRepository.InstractorIsExist(department.InsManger);
                if (!instractorIsExist)
                    return Result.Failure(InstractorErrors.InstructorNotFound);
                var instractorIsAlreadyManageDepartment = await _departmentRepository.InstractorIsAlreadyManageDepartment(department.InsManger);
                if (instractorIsAlreadyManageDepartment)
                    return Result.Failure(DepartmentErrors.InstructorAlreadyManageDepartment);
            }
            await _departmentRepository.AddDepartmentAsync(department);
            return Result.Success();
        }


        public async Task<Department> GetDeparmentById(int id)
        {
            return await _departmentRepository.GetDepartmentById(id);
        }

        public async Task<Result> UpdateDepartmentAsync(Department department)
        {
            var DepartmentIsExist = await _departmentRepository.DepartmentISFound(department.DID);
            if (!DepartmentIsExist)
                return Result.Failure(DepartmentErrors.DepartmentNotFound);
            var NameDepartmetArIsAlreadyUsed = await _departmentRepository.NameArIsExistExcludeSelf(department.DNameAr, department.DID);
            if (NameDepartmetArIsAlreadyUsed)
                return Result.Failure(DepartmentErrors.DepartmentArNameIsExist);
            var NameDepaertmentEnIsAlreayUsed= await _departmentRepository.NameEnIsExistExcludeSelf(department.DNameEn, department.DID);
            if(NameDepaertmentEnIsAlreayUsed)
                return Result.Failure(DepartmentErrors.DepartmentEnNameIsExist);
            if (department.InsManger != null)
            {
                var instractorIsExist = await _instractorRepository.InstractorIsExist(department.InsManger);
                if (!instractorIsExist)
                    return Result.Failure(InstractorErrors.InstructorNotFound);
                var instractorIsAlreadyManageDepartmentExcludeSelft = await _departmentRepository.InstractorIsAlreadyManageDepartmentExcludeSlef(department.InsManger,department.DID);
                if (instractorIsAlreadyManageDepartmentExcludeSelft)
                    return Result.Failure(DepartmentErrors.InstructorAlreadyManageDepartment);
            }
            await _departmentRepository.UpdateDepartmentAsync(department);
            return Result.Success();
        }
        public async Task<Result> DeleteDepartmentAsync(int Id)
        {
            var Department= await _departmentRepository.DepartmentISFound(Id);
            if (!Department)
                return Result.Failure(DepartmentErrors.DepartmentNotFound);
            await _departmentRepository.DeleteDepartmentAsync(Id);
            return Result.Success();
        }

        public async Task<Result<List<Department>>> GetAllDepartment()
        {
           var result= await _departmentRepository.GetAllDepartmentAsync();
            return Result.Success(result);
        }

        public async Task<Result<List<ViewDepartment>>> GetDepartmentStudentCountAsync()
        {
            var result = await _viewRepository.GetTableNoTracking().ToListAsync();
            return Result.Success(result);
        }

        public async Task<Result<IReadOnlyList<DepartmentStudentCountProc>>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParameters parameters)
        {
            var result= await _departmentStudentCountProcRepository.GetDepartmentStudentCount(parameters);
            if (result.FirstOrDefault() == null)
                return Result.Failure<IReadOnlyList<DepartmentStudentCountProc>>(DepartmentErrors.DepartmentNotFound);
            return Result.Success(result);
        }
    }
}
