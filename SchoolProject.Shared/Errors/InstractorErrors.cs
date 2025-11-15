using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class InstractorErrors
    {
        public readonly static Error NameArExists =
            new Error("Instructor.NameArExists", "Arabic name already exists.", StatusCodes.Status409Conflict);

        public readonly static Error NameEnExists =
            new Error("Instructor.NameEnExists", "English name already exists.", StatusCodes.Status409Conflict);
        public readonly static Error FailedToAddInstructor =
            new Error("Instructor.FailedToAdd", "Failed to add instructor.", StatusCodes.Status500InternalServerError);
        public readonly static Error SupervisorNotFound =
    new Error("Instructor.SupervisorNotFound", "Supervisor not found.", StatusCodes.Status404NotFound);
        public static readonly Error SupervisorCannotBeSelf =
    new Error(
        "Instructor.SupervisorCannotBeSelf",
        "Supervisor cannot be the same as the instructor.",
        StatusCodes.Status400BadRequest
    );
        public readonly static Error InstructorNotFound =
    new Error("Instructor.NotFound", "Instructor not found.", StatusCodes.Status404NotFound);
        public readonly static Error FailedToUpdateInstructor =
            new Error("Instructor.FailedToUpdate", "Failed to Update instructor.", StatusCodes.Status500InternalServerError);
    }
}
