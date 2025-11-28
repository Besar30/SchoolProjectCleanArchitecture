using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.response;
using SchoolProject.Core.pagination;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Handler
{
    public class SubjectQueryHandler(ISubjectService subjectService,IMapper mapper) : 
                                                                                IRequestHandler<GetAllSubjectRequestQuery, Result<PaginatedList<GetAllSubjectResponse>>>,
                                                                                IRequestHandler<GetSubjectByIdRequestQuery,Result<GetSubjectByIdResponse>>
    {
        private readonly ISubjectService _subjectService = subjectService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginatedList<GetAllSubjectResponse>>> Handle(GetAllSubjectRequestQuery request, CancellationToken cancellationToken)
        {
            var Subjects = _subjectService.GetAllSubject();
            if (!string.IsNullOrEmpty(request._requestFilters.SortColume))
            {
                var direction = request._requestFilters.SortDirection?.ToLower() == "desc" ? "desc" : "asc";

                Subjects = Subjects.OrderBy($"{request._requestFilters.SortColume} {direction}");
            }
           
            var pagination = request._requestFilters;
            var SubjectPagination = await PaginatedList<Subject>.CreateAsync(Subjects, pagination.PageNumber, pagination.PageSize, cancellationToken);
            var SubjectMapped = _mapper.Map<List<GetAllSubjectResponse>>(SubjectPagination.Items);
            var result = new PaginatedList<GetAllSubjectResponse>
            (
                SubjectMapped,
                SubjectPagination.PageNumber,
                SubjectPagination.TotalPages
            );
            return Result.Success(result);
        }

        public async Task<Result<GetSubjectByIdResponse>> Handle(GetSubjectByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var subject = await _subjectService.GetSubjectById(request.Id);
            if (subject.isFailure)
                return Result.Failure<GetSubjectByIdResponse>(subject.error);
            var subjectResponse=  _mapper.Map<GetSubjectByIdResponse>(subject.Value);
            return Result.Success(subjectResponse);
        }
    }
}
