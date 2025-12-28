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
    public class StudentSubjectServices(IStudentSubjectRepository studentSubjectRepository , ISubjectRepository subjectRepository,IStudentRepository studentRepository) : IStudentSubjectServices
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository = studentSubjectRepository;
        private readonly ISubjectRepository _subjectRepository = subjectRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<Result> AddStudentSubjectAsync(StudentSubject studentSubject)
        {
            var studentIsExist = await _studentRepository.StudentIsExist(studentSubject.StudID);
            if (!studentIsExist)
                return Result.Failure(StudentErrors.StudentNotFound);
            var SubjectNotFound = await _subjectRepository.SubjectIsExist(studentSubject.SubID);
            if (!SubjectNotFound)
                return Result.Failure(SubjectErrors.SubjectNotFound);
     
            var studentSubjectIsAlreadyExist = await _studentSubjectRepository.StudentSubjectIsExistAlready(studentSubject.StudID, studentSubject.SubID);
            if (studentSubjectIsAlreadyExist)
                return Result.Failure(StudentSubjectErrors.StudentSubjectIsAlreadyExist);
            await _studentSubjectRepository.AddStudentSubjectAsync(studentSubject);
            return Result.Success();
        }

        public async Task<Result> UpdateStudentSubjectAsync(StudentSubject studentSubject)
        {
            var studentIsExist = await _studentRepository.StudentIsExist(studentSubject.StudID);
            if (!studentIsExist)
                return Result.Failure(StudentErrors.StudentNotFound);
            var SubjectNotFound = await _subjectRepository.SubjectIsExist(studentSubject.SubID);
            if (!SubjectNotFound)
                return Result.Failure(SubjectErrors.SubjectNotFound);
            var studentSubjectIsEist = await _studentSubjectRepository.StudentSubjectIsExistAlready(studentSubject.StudID, studentSubject.SubID);
            if (!studentSubjectIsEist)
                return Result.Failure(StudentSubjectErrors.StudentSubjectNotFound);
            await _studentSubjectRepository.UpdateStudentSubjectAsync(studentSubject);
            return Result.Success();
        }
    }
}
