using SchoolProject.Core.Features.Departments.Queires.Models;
using SchoolProject.Core.Features.Departments.Queires.Responses;
using SchoolProject.Data.Entites.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        void GetDepartmentStudentCountByIdProcMapping()
        {
            CreateMap<GetDepartmentStudentCountByIdProcQuery, DepartmentStudentCountProcParameters>()
                .ForMember(des => des.DId, opt => opt.MapFrom(src => src.Id));
            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountProcByIdResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr!, src.DNameEn!)));
        }
    }
}
