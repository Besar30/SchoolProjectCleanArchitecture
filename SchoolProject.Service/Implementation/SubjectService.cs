using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class SubjectService (ISubjectRepository subjectRepository): ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;

        public async Task<Result> AddSubjectAsync(Subject subject)
        {
            //check if nameAr is found
            var NameArIsExist= await _subjectRepository.SubjectNameArIsAlreadyExist(subject.SubjectNameAr!);
            if (NameArIsExist)
                return Result.Failure(SubjectErrors.NameArExists);
            //check if nameAr is found
            var NameEnIsExist =await _subjectRepository.SubjectNameEnIsAlreadyExist(subject.SubjectNameEn!);
            if (NameEnIsExist)
                return Result.Failure(SubjectErrors.NameEnExists);
            await _subjectRepository.AddSubjectAsync(subject);
            return Result.Success();
        }

        public async Task<IQueryable<Subject>> GetAllSubject()
        {
            var result=await _subjectRepository.GetAllSubjects();
            return result;
        }
    }
}
