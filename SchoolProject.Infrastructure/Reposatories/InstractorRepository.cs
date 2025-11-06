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
    }
}
