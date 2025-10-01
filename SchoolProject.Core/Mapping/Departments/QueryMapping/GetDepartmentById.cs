using SchoolProject.Core.Features.Departments.Queires.Responses;
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
        public void GetDepartmentById()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(des=>des.ManagerName,otp=>otp.MapFrom(src=>src.instractor.GetLocalized(src.instractor.ENameAr,src.instractor.ENameEn)))
                .ForMember(des=>des.SubjectList,otp=>otp.MapFrom(src=>src.DepartmentSubjects))
                .ForMember(des => des.StudentList, otp => otp.MapFrom(src => src.Students))
                .ForMember(des => des.InstructorList, otp => otp.MapFrom(src => src.instractors));

            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(des => des.ID, otp => otp.MapFrom(src => src.SubID))
                .ForMember(des => des.Name, otp => otp.MapFrom(src => src.Subjects.GetLocalized(src.Subjects.SubjectNameAr,src.Subjects.SubjectNameEn)));

            CreateMap<Student, StudentResponse>()
          .ForMember(des => des.ID, otp => otp.MapFrom(src => src.StudentID))
          .ForMember(des => des.Name, otp => otp.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));

            CreateMap<Instractor, InstructorResponse>()
              .ForMember(des => des.ID, otp => otp.MapFrom(src => src.InsId))
              .ForMember(des => des.Name, otp => otp.MapFrom(src => src.GetLocalized(src.ENameAr,src.ENameEn)));
        }
    }
}
