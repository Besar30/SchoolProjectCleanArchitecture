using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IInstractorRepository
    {
        public Task<bool> NameArIsExist(string name);
        public Task<bool> NameEnIsExist(string name);
        public Task<bool> NameArIsExistExcludeSelf(string nameAr, int id);
        public Task<bool> NameEnIsExistExcludeSelf(string nameEn, int id);
        public Task<bool> SuperVisorToInstractorIsExist(int?  id);
        public Task AddInstractorAsync(Instractor instractor);
        public Task<Instractor> GetInstructorById(int Id);
        public Task <Instractor> GetInstructorByName(string Name);
        public Task<List<Instractor>> GetAllInstractors();
        public Task<bool> InstractorIsExist(int? Id);
        public Task<bool> InstractorIsExistByName(string Name);
        public Task ToggleStatusInstractor(int Id);
        public Task UpdateInstractorAsync(Instractor instractor);
        public Task DeleteInstractorAsync(int Id);

    }
}
