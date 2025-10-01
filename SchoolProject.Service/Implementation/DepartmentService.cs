using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public async Task<Department> GetDeparmentById(int id)
        {
            return await _departmentRepository.GetDepartmentById(id);
        }
    }
}
