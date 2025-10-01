using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SchoolProject.Core.Features.Students.Queires.Models;
using SchoolProject.Core.Features.Students.Queires.Response;
using SchoolProject.Core.pagination;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace SchoolProject.Core.Features.Students.Queires.Handlers
{
    public class StudentHandler(IStudentService studentService,IMapper mapper) : IRequestHandler<GetStudentListQuery, Result<PaginatedList<StudentResponse>>>,
                                                                                   IRequestHandler<GetStudentByIdQuery, Result<StudentResponse>>   
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginatedList<StudentResponse>>> Handle(GetStudentListQuery request,CancellationToken cancellationToken)
        {
            var response = await _studentService.GetStudentsListAsync();
            var query = response.Value;
            if (!string.IsNullOrEmpty(request.RequestFilters.SortColume)) {
                query = query.OrderBy($"{request.RequestFilters.SortColume} {request.RequestFilters.SortDirection}");
            }
            var mappedQuery = query.ProjectTo<StudentResponse>(_mapper.ConfigurationProvider);
            var result = await PaginatedList<StudentResponse>.CreateAsync(
                          mappedQuery,
                          request.RequestFilters.PageNumber,
                          request.RequestFilters.PageSize,
                          cancellationToken
                      );         
            return Result.Success(result);
        }

        public async Task<Result<StudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(request.Id);
            if (student.isFailure)
                return Result.Failure<StudentResponse>(StudentErrors.StudentNotFound);
            var response= _mapper.Map<StudentResponse>(student.Value);
            return Result.Success(response);
        }
    }
}
