using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Handler
{
    public class DepartmentCommandHandler (IMapper mapper,IDepartmentService departmentService): 
                                                                                                IRequestHandler<AddDepartmentRequestCommand, Result<string>>,
                                                                                                IRequestHandler<UpdateDepartmentRequestCommand,Result<string>>,
                                                                                                IRequestHandler<DeleteDepartmentRequestCommand,Result<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDepartmentService _departmentService = departmentService;

        public async Task<Result<string>> Handle(AddDepartmentRequestCommand request, CancellationToken cancellationToken)
        {
            var DepartmentMapped = _mapper.Map<Department>(request);
            var result= await _departmentService.AddDepartmentAsync(DepartmentMapped);
            return result.IsSuccess ? Result.Success("Department Add Success.")
                : Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(UpdateDepartmentRequestCommand request, CancellationToken cancellationToken)
        {
            var DepaetmentMapped= _mapper.Map<Department>(request);
            var result = await _departmentService.UpdateDepartmentAsync(DepaetmentMapped);
            return result.IsSuccess?
                Result.Success("Department Updated Success."): Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(DeleteDepartmentRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteDepartmentAsync(request.Id);
            return result.IsSuccess?
                Result.Success("Department Deleted Success."):Result.Failure<string>(result.error);
        }
    }
}
