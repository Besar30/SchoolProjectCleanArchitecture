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
    public class InstractorRepository(ApplicationDBContext context) : IInstractorRepository
    {
        private readonly ApplicationDBContext _context = context;

        public Task<bool> NameArIsExist(string name)
        {
            return _context.instractors.AnyAsync(x=>x.ENameAr==name);
        }

        public Task<bool> NameEnIsExist(string name)
        {
            return _context.instractors.AnyAsync(x => x.ENameEn == name);
        }
        public Task<bool> NameArIsExistExcludeSelf(string nameAr, int id)
        {
            return _context.instractors
                .AnyAsync(x => x.ENameAr == nameAr && x.InsId != id);
        }

        public Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id)
        {
            return _context.instractors
                .AnyAsync(x => x.ENameEn == nameEn && x.InsId != id);
        }

        public async Task AddInstractorAsync(Instractor instractor)
        {
            await _context.instractors.AddAsync(instractor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SuperVisorToInstractorIsExist(int? id)
        {
            return await _context.instractors.AnyAsync(x => x.InsId == id );
        }
        public async Task<bool> InstractorIsExist(int? Id)
        {
            return await _context.instractors.AnyAsync(x=>x.InsId==Id);
        }

        public async Task<Instractor> GetInstructorById(int Id)
        {
           var respone= await _context.instractors.Where(x=>x.InsId == Id)
                                                  .Include(x=>x.Ins_Subjects).ThenInclude(x=>x.subject)
                                                  .Include(x=>x.department)
                                                  .Include(x => x.Instractors)
                                                  .Include(x=>x.Supervisor)
                                                  
                                                  .SingleOrDefaultAsync();
            return respone;
                                                  
        }

        public async Task UpdateInstractorAsync(Instractor newData)
        {
            var old = await _context.instractors
                                .FirstAsync(x => x.InsId == newData.InsId);
            old.ENameAr = newData.ENameAr;
            old.ENameEn = newData.ENameEn;
            old.Address = newData.Address;
            old.Position = newData.Position;
            old.SupervisorId = newData.SupervisorId;
            old.Salary = newData.Salary;
            old.DID = newData.DID;
            old.Image = newData.Image;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Instractor>> GetAllInstractors()
        {
            return await _context.instractors.
                                            Include(x=>x.department)
                                            .Include(x=>x.Ins_Subjects).ThenInclude(x=>x.subject).Include(x=>x.Instractors)
                                            .ToListAsync();
        }

        public async Task DeleteInstractorAsync(int Id)
        {
            var instractor= await _context.instractors.Where(x=>x.InsId == Id).FirstAsync();
            _context.Remove(instractor!);
            await _context.SaveChangesAsync();
        }

        public async Task<Instractor> GetInstructorByName(string Name)
        {
            var respone = await _context.instractors.Where(x => x.ENameAr == Name || x.ENameEn==Name)
                                                  .Include(x => x.Ins_Subjects).ThenInclude(x => x.subject)
                                                  .Include(x => x.department)
                                                  .Include(x => x.Instractors)
                                                  .Include(x => x.Supervisor)
                                                  .SingleOrDefaultAsync();
            return respone;
        }

        public async Task<bool> InstractorIsExistByName(string Name)
        {
            return await _context.instractors.AnyAsync(x=>x.ENameAr==Name || x.ENameEn==Name);
        }

        public async Task ToggleStatusInstractor(int Id)
        {
            var Instractor= await _context.instractors.Where(x=>x.InsId==Id).FirstAsync();
            Instractor.IsDisabled= !Instractor.IsDisabled;
            await _context.SaveChangesAsync();
        }
    }
}
