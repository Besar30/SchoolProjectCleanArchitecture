using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Handler
{
    public class SubjectCommandHandler(IMapper mapper,ISubjectService subjectService) : 
                                                                                      IRequestHandler<AddSubjectRequestCommand, Result<string>>,
                                                                                      IRequestHandler<UpdateSubjectRequestCommand, Result<string>>,
                                                                                      IRequestHandler<DeleteSubjectRequestCommand,Result<string>> 
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISubjectService _subjectService = subjectService;

        public async Task<Result<string>> Handle(AddSubjectRequestCommand request, CancellationToken cancellationToken)
        {
            var SubjectMapped= _mapper.Map<Subject>(request);
            var result = await _subjectService.AddSubjectAsync(SubjectMapped);
            return result.IsSuccess ?
                Result.Success("Subject Added successfully.") : Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(UpdateSubjectRequestCommand request, CancellationToken cancellationToken)
        {
            var SubjectMapped = _mapper.Map<Subject>(request);
            var result= await _subjectService.UpdateSubject(SubjectMapped);
            return result.IsSuccess?
                Result.Success("Subject Updated successfully.") :Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(DeleteSubjectRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectService.DeleteSubjectAsync(request.Id);
            return result.IsSuccess ?
               Result.Success("Subject Deleted successfully.") : Result.Failure<string>(result.error);
        }
    }
}
