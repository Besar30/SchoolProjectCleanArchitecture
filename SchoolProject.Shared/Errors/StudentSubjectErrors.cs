using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class StudentSubjectErrors
    {
        public readonly static Error StudentSubjectIsAlreadyExist =
            new Error(
                 "StudentSubjectIsAlreadyExist",
                 "This student is already registered in this subject.",
                StatusCodes.Status409Conflict);
    }
}
