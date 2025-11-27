using SchoolProject.Data.Entites;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<Result> AddSubjectAsync(Subject subject);
        public IQueryable<Subject> GetAllSubject();
    }
}
