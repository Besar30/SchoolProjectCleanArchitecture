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



        public IQueryable<Subject> GetAllSubject()
        {
            var result=_subjectRepository.GetAllSubjects();
            return result;
        }

        public async Task<Result<Subject>> GetSubjectById(int Id)
        {
           var subject= await _subjectRepository.GetSubjectById(Id);
            if (subject == null)
                return Result.Failure<Subject>(SubjectErrors.SubjectNotFound);
            return Result.Success(subject);
        }

        public async Task<Result> UpdateSubject(Subject subject)
        {
            var SubjectIsExist = await _subjectRepository.GetSubjectByIdToUpdate(subject.SubID);
            if (SubjectIsExist == null)
                return Result.Failure(SubjectErrors.SubjectNotFound);
            var NewSubjectNameArAlreadyExist= await _subjectRepository.NameArIsExistExcludeSelf(subject.SubjectNameAr!,subject.SubID);
            if (NewSubjectNameArAlreadyExist)
                return Result.Failure(SubjectErrors.NameArExists);
            var NewSubjectNameEnAlreadyExist= await _subjectRepository.NameEnIsExistExcludeSelf(subject.SubjectNameEn!,subject.SubID);
            if (NewSubjectNameEnAlreadyExist)
                return Result.Failure(SubjectErrors.NameEnExists);
            await _subjectRepository.UpdateSubject(subject);
            return Result.Success();
        }
        public async Task<Result> DeleteSubjectAsync(int Id)
        {
            var Subject = await _subjectRepository.GetSubjectByIdToUpdate(Id);
            if (Subject == null)
                return Result.Failure(SubjectErrors.SubjectNotFound);
            await _subjectRepository.DeleteSubjectAsync(Subject);
            return Result.Success();
        }

    }
}
