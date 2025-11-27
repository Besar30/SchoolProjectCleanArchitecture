using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace SchoolProject.Infrastructure.Reposatories
{
    public class DepartmentRepository(ApplicationDBContext context) : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task AddDepartmentAsync(Department department)
        {
           await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DepartmentISFound(int? id)
        {
          return await _context.Departments.AnyAsync(x=> x.DID == id);
        }
        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _context.Departments.Include(x => x.Students)
                                         .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                         .Include(x => x.instractors)
                                         .Include(x => x.instractor).ToListAsync();
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

        public async Task<bool> InstractorIsAlreadyManageDepartment(int? Id)
        {
            return await _context.Departments.AnyAsync(x => x.InsManger == Id);
        }

        public async Task<bool> NameArDepartmentIsExist(string name)
        {
            return await _context.Departments.AnyAsync(x=>x.DNameAr==name);
        }

        public Task<bool> NameArIsExistExcludeSelf(string nameAr, int id)
        {
            return _context.Departments
                           .AnyAsync(x => x.DNameAr == nameAr && x.DID != id);
        }

        public Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id)
        {
            return _context.Departments
                                      .AnyAsync(x => x.DNameEn == nameEn && x.DID != id);
        }
        public async Task<bool> NameEnDepartmentIsExist(string name)
        {
            return await _context.Departments.AnyAsync(x => x.DNameEn == name);
        }

     

        public async Task UpdateDepartmentAsync(Department department)
        {
            var oldDepartment = await _context.Departments.Where(x => x.DID == department.DID).FirstOrDefaultAsync();
            oldDepartment.DNameAr=department.DNameAr;
            oldDepartment.DNameEn=department.DNameEn;
            oldDepartment.InsManger=department.InsManger;
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> InstractorIsAlreadyManageDepartmentExcludeSlef(int? InsId, int DeptId)
        {
           return await _context.Departments.AnyAsync(x=>x.InsManger==InsId && x.DID!=DeptId);
        }

        public async Task DeleteDepartmentAsync(int Id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DID == Id);
            _context.Departments.Remove(department!);
            await _context.SaveChangesAsync();
        }


    }
}
