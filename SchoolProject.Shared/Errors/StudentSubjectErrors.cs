using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Shared.Errors
{
    public static class StudentSubjectErrors
    {
        public readonly static Error StudentSubjectIsAlreadyExist =
            new Error(
                 "StudentSubjectIsAlreadyExist",
                 "This student is already registered in this subject.",
                StatusCodes.Status409Conflict);
        public readonly static Error StudentSubjectNotFound =
            new Error(
                "StudentSubjectNotFound",
                "This student is not registered in this subject.",
                StatusCodes.Status404NotFound);

    }
}
