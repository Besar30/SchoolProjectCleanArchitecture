using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Shared.Errors
{
    public static class StudentErrors
    {
        public static readonly Error StudentNotFound =
            new("Student.StudentNotFound", "Student is not found", StatusCodes.Status404NotFound);

        public static readonly Error NameStudentDuplicated =
            new("Student.StudentFound", "Name Student is already here ,Please Enter anthor Name", StatusCodes.Status400BadRequest);
    }
}
