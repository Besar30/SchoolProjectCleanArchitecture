using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentById(int id);
        Task<bool>DepartmentISFound(int? id);
        Task AddDepartmentAsync(Department department);
        Task<bool>NameArDepartmentIsExist(string name);
        Task<bool> NameEnDepartmentIsExist(string name);
        public Task<bool> NameArIsExistExcludeSelf(string nameAr, int id);
        public Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id);
        Task<bool> InstractorIsAlreadyManageDepartment( int? Id);
        Task UpdateDepartmentAsync(Department department);
        Task<bool> InstractorIsAlreadyManageDepartmentExcludeSlef( int? InsId,int DeptId);
        Task DeleteDepartmentAsync(int Id);
        Task<List<Department>> GetAllDepartmentAsync();

    }
}
