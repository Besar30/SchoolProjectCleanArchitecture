using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public async Task<Result<Instractor>> GetInstractorById(int id)
        {
            //instractor is Exist
           var InstractorIsExsit = await _instractorRepository.InstractorIsExist(id);
            if (!InstractorIsExsit)
                return Result.Failure<Instractor>(InstractorErrors.InstructorNotFound);
            var result= await _instractorRepository.GetInstructorById(id);
            return Result.Success(result);
        }

        public async Task<Result<string>> UpdateInstractor(Instractor instractor,IFormFile ImageFile)
        {
            var InstractorIsExist = await _instractorRepository.InstractorIsExist(instractor.InsId);
            if (!InstractorIsExist)
                return Result.Failure<string>(InstractorErrors.InstructorNotFound);
            var NameInstractorArIsExist=await _instractorRepository.NameArIsExistExcludeSelf(instractor.ENameAr, instractor.InsId);
            if (NameInstractorArIsExist)
                return Result.Failure<string>(InstractorErrors.NameArExists);
            var NameInstractorEnIsExist=await _instractorRepository.NameEnIsExistExcludeSelf(instractor.ENameEn, instractor.InsId);
            if (NameInstractorEnIsExist)
                return Result.Failure<string>(InstractorErrors.NameEnExists);
            if(instractor.DID!=null)
            {
                var DepartmentIsExist = await _departmentRepository.DepartmentISFound(instractor.DID);
                if (!DepartmentIsExist)
                    return Result.Failure<string>(DepartmentErrors.DepartmentNotFound);
            }
            if (instractor.SupervisorId != null) {
                var InstractorSuperVisorIsExist = await _instractorRepository.SuperVisorToInstractorIsExist(instractor.SupervisorId);
                if (!InstractorSuperVisorIsExist)
                    return Result.Failure<string>(InstractorErrors.SupervisorNotFound);
            }
            if (ImageFile != null)
            {
                var PathImage = await _fileService.UploadImage("Instractors", ImageFile);
                if (PathImage.IsSuccess)
                    instractor.Image = PathImage.Value;
                else
                    return Result.Failure<string>(InstractorErrors.FailedToUpdateInstructor);
            }
            else
            {
                var oldInstructor = await _instractorRepository.GetInstructorById(instractor.InsId);

                instractor.Image = oldInstructor.Image;
            }
            await _instractorRepository.UpdateInstractorAsync(instractor);
            return Result.Success("Instructor Updated Success.");
        }

        public async Task<Result<List<Instractor>>> GetAllInstructorsAsync()
        {
            var result = await _instractorRepository.GetAllInstractors();
            return Result.Success(result);
        }

        public async Task<Result> DeleteInstractorAsync(int Id)
        {
            var InstractorIsExist = await _instractorRepository.InstractorIsExist(Id);
            if (!InstractorIsExist)
                return Result.Failure(InstractorErrors.InstructorNotFound);
            await _instractorRepository.DeleteInstractorAsync(Id);
            return Result.Success();
        }

        public async Task<Result<Instractor>> GetInstractorByName(string Name)
        {
            var instractorIsExist= await _instractorRepository.InstractorIsExistByName(Name);
            if (!instractorIsExist)
                return Result.Failure<Instractor>(InstractorErrors.InstructorNotFound);
            var result = await _instractorRepository.GetInstructorByName(Name);
            return Result.Success(result);
        }

        public async Task<Result> ToggleStatusInstractor(int Id)
        {
            var InstractorIsExist = await _instractorRepository.InstractorIsExist(Id);
            if (!InstractorIsExist)
                return Result.Failure(InstractorErrors.InstructorNotFound);
            await _instractorRepository.ToggleStatusInstractor(Id);
            return Result.Success();
        }
    }
}
