using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class DepartmentErrors
    {
        public static readonly Error DepartmentNotFound = new("Department.DepartmentNotFound", "Department is not found", StatusCodes.Status404NotFound);
        public static readonly Error DepartmentArNameIsExist =
            new("Department.ArabicNameIsExist", "Arabic department name is already exist", StatusCodes.Status409Conflict);
        public static readonly Error DepartmentEnNameIsExist =
    new("Department.EnglishNameIsExist", "English department name is already exist", StatusCodes.Status409Conflict);
        public static readonly Error InstructorAlreadyManageDepartment =
    new("Department.InstructorAlreadyManageDepartment",
        "This instructor already manages another department",
        StatusCodes.Status409Conflict);

    }
}
