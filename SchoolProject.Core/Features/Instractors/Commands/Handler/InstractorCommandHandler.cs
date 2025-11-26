using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Commands.Handler
{
    public class InstractorCommandHandler(IFileService fileService,IMapper mapper,IInstractorService instractorService) : 
        IRequestHandler<AddInstractorCommand, Result<string>>,
        IRequestHandler<UpdateInstractorCommand,Result<string>>,
        IRequestHandler<DeleteInstractorRequest,Result<string>>,
        IRequestHandler<ToggleStatusInstractorCommand,Result<string>>
    {
        private readonly IFileService _fileService = fileService;
        private readonly IMapper _mapper = mapper;
        private readonly IInstractorService _instractorService = instractorService;

        public async Task<Result<string>> Handle(AddInstractorCommand request, CancellationToken cancellationToken)
        {
            //check if nameAr Is Found
            var NameARIsExist = await _instractorService.IsNameArExist(request.ENameAr!);
            if (NameARIsExist)
                return Result.Failure<string>(InstractorErrors.NameArExists);
            //check if nameen is Found
            var NameEnIsExist = await _instractorService.IsNameEnExist(request.ENameEn!);
            if (NameEnIsExist)
                return Result.Failure<string>(InstractorErrors.NameEnExists);
           var instructor=_mapper.Map<Instractor>(request);
           var result= await _instractorService.AddInstructorAsync(instructor,request.Image);
            if (!result.IsSuccess)
                return Result.Failure<string>(result.error);
            return Result.Success("Instructor added successfully.");
        }

        public async Task<Result<string>> Handle(UpdateInstractorCommand request, CancellationToken cancellationToken)
        {
           var instractorMapped= _mapper.Map<Instractor>(request);
            var result= await _instractorService.UpdateInstractor(instractorMapped,request.Image);
            return result.IsSuccess?
                Result.Success(result.Value): Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(DeleteInstractorRequest request, CancellationToken cancellationToken)
        {
            var result = await _instractorService.DeleteInstractorAsync(request.Id);
            return result.IsSuccess?
                Result.Success("Instructor Deleted successfully.") :Result.Failure<string>(result.error);
        }

        public async Task<Result<string>> Handle(ToggleStatusInstractorCommand request, CancellationToken cancellationToken)
        {
            var result = await _instractorService.ToggleStatusInstractor(request.Id);
            return result.IsSuccess ?
                Result.Success("Instructor ToggleStatus successfully.") : Result.Failure<string>(result.error);
        }
    }
}
