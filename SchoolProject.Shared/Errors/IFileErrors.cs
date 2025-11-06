using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class IFileErrors
    {
        public readonly static Error FailedUploadImage =
            new Error("Upload.Failed", "Failed to upload the image.", StatusCodes.Status400BadRequest);
    }
}
