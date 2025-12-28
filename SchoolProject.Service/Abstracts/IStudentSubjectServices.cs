using SchoolProject.Data.Entites;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentSubjectServices
    {
        public Task<Result> AddStudentSubjectAsync(StudentSubject studentSubject);
        public Task<Result> UpdateStudentSubjectAsync(StudentSubject studentSubject);
    }
}
