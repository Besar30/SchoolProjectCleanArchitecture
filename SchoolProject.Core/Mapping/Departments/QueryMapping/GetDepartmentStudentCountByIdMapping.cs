using SchoolProject.Core.Features.Departments.Queires.Responses;
using SchoolProject.Data.Entites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        void GetDepartmentStudentCountByIdMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentCountResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(des => des.DID, opt => opt.MapFrom(src => src.DID))
                .ForMember(des=>des.StudentCount,opt=>opt.MapFrom(src=>src.StudentCount));
        }
    }
}
