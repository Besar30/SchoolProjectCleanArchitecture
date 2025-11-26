using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Features.Instractors.Queries.Models;
using SchoolProject.Core.Features.Instractors.Queries.Responses;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Core.Features.Instractors.Queries.Handler
{
    public class InstractorQueryHandler (IInstractorService instractorService, IMapper mapper,IHttpContextAccessor httpContextAccessor) : 
                                                                                                IRequestHandler<GetInstractorByIdQuery, Result<GetInstractorByIdResponse>>
                                                                                                ,IRequestHandler<GetAllInstractorQuery,Result<List<GetAllInstractorResponse>>>,
                                                                                                 IRequestHandler<GetInstractorByNameQuery,Result<GetInstractorByIdResponse>>
    {
        private readonly IInstractorService _instractorService = instractorService;
        private readonly IMapper _mapper = mapper;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<Result<GetInstractorByIdResponse>> Handle(GetInstractorByIdQuery request, CancellationToken cancellationToken)
        {
            var resutl= await _instractorService.GetInstractorById(request.Id);
            if(resutl.isFailure)
                return Result.Failure<GetInstractorByIdResponse>(resutl.error);
            //maping
            var respone = _mapper.Map<GetInstractorByIdResponse>(resutl.Value);
            var RequestAccessor = _httpContextAccessor.HttpContext.Request;
            respone.ImageFile = $"{RequestAccessor.Scheme + "://" + RequestAccessor.Host + resutl.Value.Image}";
            return Result.Success(respone);
        }

        public async Task<Result<List<GetAllInstractorResponse>>> Handle(GetAllInstractorQuery request, CancellationToken cancellationToken)
        {
            var Instractors = await _instractorService.GetAllInstructorsAsync();
            var InstractorsMapped= _mapper.Map<List<GetAllInstractorResponse>>(Instractors.Value);
            return Result.Success(InstractorsMapped);
        }

        public async Task<Result<GetInstractorByIdResponse>> Handle(GetInstractorByNameQuery request, CancellationToken cancellationToken)
        {
            var instractor= await _instractorService.GetInstractorByName(request.Name);
            if (instractor.isFailure)
                return Result.Failure<GetInstractorByIdResponse>(instractor.error);
            var instracorMapped = _mapper.Map<GetInstractorByIdResponse>(instractor.Value);
            var RequestAccessor = _httpContextAccessor.HttpContext.Request;
            instracorMapped.ImageFile= $"{RequestAccessor.Scheme + "://" + RequestAccessor.Host + instractor.Value.Image}";
            return Result.Success(instracorMapped);
        }
    }
}
