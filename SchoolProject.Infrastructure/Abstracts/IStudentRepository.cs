using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository
    {
        public Task<IQueryable<Student>> GetStudentsListAsync();
        public Task<Student?> GetStudentById(int Id);
        public Task<bool> StudentIsExist(int Id);
        public Task AddStudentAsync(Student student);
        public Task<bool> CheckStudentFound(string Name);
        public Task EditStudentAsync(Student student);
        public Task<bool> CheckStudentFound(string name,int Id);
        public Task DeleteStudentAsync(int Id);
        public Task ToggleStatusStudentAsync(int Id);


    }
}
