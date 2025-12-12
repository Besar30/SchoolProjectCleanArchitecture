using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class SubjectErrors
    {
        public readonly static Error NameArExists =
                  new Error("Subject.NameArExists", "Arabic name already exists.", StatusCodes.Status409Conflict);
        public readonly static Error NameEnExists =
                 new Error("Subject.NameEnExists", "English name already exists.", StatusCodes.Status409Conflict);
        public static readonly Error SubjectNotFound =
           new("Subject.SubjectNotFound", "Subject is not found", StatusCodes.Status404NotFound);
    }
}
