using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entites;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Service.Abstracts
{
    public interface IInstractorService
    {
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<Result<string>> AddInstructorAsync(Instractor instructor, IFormFile fileImage);
        public Task<Result<Instractor>> GetInstractorById(int id);
        public Task<Result<Instractor>> GetInstractorByName(String Name);
        public Task<Result<List<Instractor>>> GetAllInstructorsAsync();
        public Task<Result<string>> UpdateInstractor(Instractor instractor,IFormFile ImageFile);
        public Task<Result> DeleteInstractorAsync(int Id);
        public Task<Result> ToggleStatusInstractor(int Id);
    }
}
