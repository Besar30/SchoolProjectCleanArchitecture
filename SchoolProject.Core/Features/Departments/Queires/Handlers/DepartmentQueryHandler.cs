using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Departments.Queires.Models;
using SchoolProject.Core.Features.Departments.Queires.Responses;
using SchoolProject.Data.Entites.Procedures;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queires.Handlers
{
    public class DepartmentQueryHandler(IDepartmentService departmentService,IMapper mapper) : IRequestHandler<GetDepartmentByIdQuery, Result<GetDepartmentByIdResponse>>,
                                                                                               IRequestHandler<GetAllDepartmentQuery,Result<List<GetDepartmentByIdResponse>>>,
                                                                                               IRequestHandler<GetDepartmentStudentCountQuery,Result<List<GetDepartmentStudentCountResponse>>>,
                                                                                               IRequestHandler<GetDepartmentStudentCountByIdProcQuery,Result<GetDepartmentStudentCountProcByIdResponse>>

    {
        private readonly IDepartmentService _departmentService = departmentService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
           //get services
           var result= await _departmentService.GetDeparmentById(request.Id);
            //check
            if (result == null) {
                return  Result.Failure<GetDepartmentByIdResponse>(DepartmentErrors.DepartmentNotFound);
            }
            //mapping
            var response= _mapper.Map<GetDepartmentByIdResponse>(result);
            //return response
            return Result.Success(response);
        }

        public async Task<Result<List<GetDepartmentByIdResponse>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var Departments = await _departmentService.GetAllDepartment();
            var DepaetmentsMapped= _mapper.Map<List<GetDepartmentByIdResponse>>(Departments.Value);
            return Result.Success(DepaetmentsMapped);
        }

        public async Task<Result<List<GetDepartmentStudentCountResponse>>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetDepartmentStudentCountAsync();
            var resultMapped = _mapper.Map<List<GetDepartmentStudentCountResponse>>(result.Value);
            return Result.Success(resultMapped);
        }

        public async Task<Result<GetDepartmentStudentCountProcByIdResponse>> Handle(GetDepartmentStudentCountByIdProcQuery request, CancellationToken cancellationToken)
        {
            var pram = _mapper.Map<DepartmentStudentCountProcParameters>(request);
            var result = await _departmentService.GetDepartmentStudentCountProc(pram);
            if (result.isFailure)
                return Result.Failure<GetDepartmentStudentCountProcByIdResponse>(result.error);
            var resultMapped= _mapper.Map<GetDepartmentStudentCountProcByIdResponse>(result.Value.First());
            return Result.Success(resultMapped);
        }
    }
}
