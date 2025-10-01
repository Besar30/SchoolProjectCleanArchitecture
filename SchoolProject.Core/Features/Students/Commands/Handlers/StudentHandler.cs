using AutoMapper;
using Azure;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentHandler(IMapper mapper, IStudentService studentService,IStringLocalizer<SharedResources> stringLocalizer) : IRequestHandler<AddStudentRequest, Result<string>>,
                                                                                                                                       IRequestHandler<EditStudentRequest, Result<string>>,
                                                                                                                                       IRequestHandler<DeleteStudentRequest,Result<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentService _studentService = studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;

        public async Task<Result<string>> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            //convert StudentRequst to Student
            var student = _mapper.Map<Student>(request);
            var response = await _studentService.AddStudentAsync(student);
            return response;
        }

        public async Task<Result<string>> Handle(EditStudentRequest request, CancellationToken cancellationToken)
        {
            // check student is found
            var StudentIsExist= await _studentService.GetStudentById(request.Id);
            if (StudentIsExist.isFailure)
                return Result.Failure<string>(StudentIsExist.error);
          // name is found
          var NameIsFound= await _studentService.NameIsFoundExcludeSelf(request.NameAr, request.Id);
            if(NameIsFound.isFailure)
                return Result.Failure<string>(NameIsFound.error);
            //Mapping 
            var student = StudentIsExist.Value;
            _mapper.Map(request, student);


            var result = await _studentService.UpdateStudentAsync(student);
            return result;
        }

        public async Task<Result<string>> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            // check student is found
            var StudentIsExist = await _studentService.GetStudentById(request.Id);
            if (StudentIsExist.isFailure)
                return Result.Failure<string>(StudentIsExist.error);
            var result = await _studentService.DeleteStudent(request.Id);
            return result;
        }
    }
}
