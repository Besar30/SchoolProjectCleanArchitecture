using SchoolProject.Data.Entites.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCount(DepartmentStudentCountProcParameters parameters);
    }
}
