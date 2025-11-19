using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        void UpdateDepartmentMapping()
        {
            CreateMap<UpdateDepartmentRequestCommand, Department>();
        }
    }
}
