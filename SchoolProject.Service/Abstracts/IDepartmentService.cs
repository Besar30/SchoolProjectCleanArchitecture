using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Procedures;
using SchoolProject.Data.Entites.Views;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDeparmentById(int id);
        Task<Result>AddDepartmentAsync(Department department);
        Task<Result>UpdateDepartmentAsync(Department department);
        Task<Result> DeleteDepartmentAsync(int Id);
        Task<Result<List<Department>>> GetAllDepartment();
        Task<Result<List<ViewDepartment>>> GetDepartmentStudentCountAsync();
        Task<Result<IReadOnlyList<DepartmentStudentCountProc>>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParameters parameters);
    }
}
