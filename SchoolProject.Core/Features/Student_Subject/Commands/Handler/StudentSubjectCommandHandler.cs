using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Student_Subject.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Core.Features.Student_Subject.Commands.Handler
{
    public class StudentSubjectCommandHandler(IMapper mapper,IStudentSubjectServices studentSubjectServices) : IRequestHandler<AddStudentSubjectCommand, Result<string>>,
                                                                                                               IRequestHandler<UpdateStudentSubjectCommand,Result<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentSubjectServices _studentSubjectServices = studentSubjectServices;

        public async Task<Result<string>> Handle(AddStudentSubjectCommand request, CancellationToken cancellationToken)
        {
            var studentSubjectMapping = _mapper.Map<StudentSubject>(request);
            var result= await _studentSubjectServices.AddStudentSubjectAsync(studentSubjectMapping);
            return result.IsSuccess ?
                    Result.Success("Student Subject Added successfully.") : Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(UpdateStudentSubjectCommand request, CancellationToken cancellationToken)
        {
            var studentSubjectMapped= _mapper.Map<StudentSubject>(request);
            var result= await _studentSubjectServices.UpdateStudentSubjectAsync(studentSubjectMapped);
            return result.IsSuccess ?
                Result.Success("Student Subject updated successfully.") : Result.Failure<string>(result.error);
        }
    }
}
