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
    }
}
