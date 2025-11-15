using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Reposatories
{
    public class DepartmentRepository(ApplicationDBContext context) : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<bool> DepartmentISFound(int? id)
        {
          return await _context.Departments.AnyAsync(x=> x.DID == id);
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            var response = await _context.Departments.Where(x=>x.DID == id)
                                         .Include(x=>x.Students)
                                         .Include(x=>x.DepartmentSubjects).ThenInclude(x=>x.Subjects)
                                         .Include(x=>x.instractors)
                                         .Include(x=>x.instractor)
                                         .FirstOrDefaultAsync();
            return response;
        }
    }
}
