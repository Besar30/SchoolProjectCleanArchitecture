using SchoolProject.Data.Entites.Procedures;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Data;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Reposatories.Procedures
{
    public class DepartmentStudentCountProcRepository(ApplicationDBContext context) : IDepartmentStudentCountProcRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCount(DepartmentStudentCountProcParameters parameters)
        {
            var rows = new List<DepartmentStudentCountProc>();
            await _context.LoadStoredProc(nameof(DepartmentStudentCountProc))
                .AddParam("@Department_Id", parameters.DId)
                .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
            return rows;
        }
    }
}
