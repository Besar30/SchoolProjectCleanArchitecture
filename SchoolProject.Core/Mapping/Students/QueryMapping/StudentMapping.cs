using SchoolProject.Core.Features.Students.Queires.Response;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void MappingStudent()
        {
            CreateMap<Student, StudentResponse>()
              .ForMember(dest => dest.StudentDepartment, opt => opt.MapFrom(src => src.GetLocalized(src.Department.DNameAr,src.Department.DNameEn)))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr,src.NameEn)));

        }
    }
}
