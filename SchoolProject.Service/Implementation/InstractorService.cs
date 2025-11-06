using Microsoft.AspNetCore.Http;
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
    public class InstractorService (IInstractorRepository instractorRepository,IFileService fileService,IDepartmentRepository departmentRepository): IInstractorService
    {
        private readonly IInstractorRepository _instractorRepository = instractorRepository;
        private readonly IFileService _fileService = fileService;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public Task<bool> IsNameArExist(string nameAr)
        {
           return _instractorRepository.NameArIsExist(nameAr);
        }

        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            return _instractorRepository.NameArIsExistExcludeSelf(nameAr, id);
        }

        public Task<bool> IsNameEnExist(string nameEn)
        {
            return _instractorRepository.NameEnIsExist(nameEn);
        }

        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            return _instractorRepository.NameEnIsExistExcludeSelf(nameEn, id);
        }
        public async Task<Result<string>> AddInstructorAsync(Instractor instructor, IFormFile fileImage)
        {
            int DepartmentId;
            if (instructor.DID != null)
            {
                DepartmentId = instructor.DID.Value;
                var result= await _departmentRepository.DepartmentISFound(DepartmentId);
                if (result == false)
                    return Result.Failure<string>(DepartmentErrors.DepartmentNotFound);
            }
            //Can not make ins to super visor to him self
            if (instructor.InsId == instructor.SupervisorId)
                return Result.Failure<string>(InstractorErrors.SupervisorCannotBeSelf);

            var superVisorIsExist = await _instractorRepository.SuperVisorToInstractorIsExist(instructor.SupervisorId);
            if (superVisorIsExist == false&&instructor.SupervisorId!=null)
                return Result.Failure<string>(InstractorErrors.SupervisorNotFound);

            var pathImage = await _fileService.UploadImage("Instractors", fileImage);
            if(pathImage.IsSuccess)
            instructor.Image = pathImage.Value;
            try
            {
                await _instractorRepository.AddInstractorAsync(instructor);
                return Result.Success("Instructor Added Success.");
            }
            catch (Exception ) {
                return Result.Failure<string>(InstractorErrors.FailedToAddInstructor);
            }
        }


    }
}
