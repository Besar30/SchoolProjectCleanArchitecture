using Microsoft.AspNetCore.Http;
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
    public class FileService : IFileService
    {
        public async Task<Result<string>> UploadImage(string Location, IFormFile? file)
        {
            if (file!=null&&file.Length > 0)
            {
                try
                {
                    var UploadFolder = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Images",
                        Location
                    );
                    if (!Directory.Exists(UploadFolder))
                    {
                        Directory.CreateDirectory(UploadFolder);
                    }
                    var UniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var FilePath = Path.Combine(UploadFolder, UniqueFileName);
                    using (var filestream = new FileStream(FilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    return Result.Success($"/Images/{Location}/{UniqueFileName}");
                }
                catch (Exception)
                {
                    return Result.Failure<string>(IFileErrors.FailedUploadImage);
                }
            }
            else
                return Result.Success($"/Images/{Location}/NoImage.jpg");

        }
    }
}
