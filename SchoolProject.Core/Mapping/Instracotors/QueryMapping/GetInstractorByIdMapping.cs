using SchoolProject.Core.Features.Instractors.Queries.Responses;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Instracotors
{
    public partial class InstractroProfile
    {
        void GetInstractorByIdMapping()
        {
            CreateMap<Instractor, GetInstractorByIdResponse>()
               .ForMember(dest => dest.Name,
                          opt => opt.MapFrom(src => src.GetLocalized(src.ENameAr, src.ENameEn)))
               .ForMember(dest => dest.Address,
                          opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Salary,
                          opt => opt.MapFrom(src => src.Salary))
               .ForMember(des=>des.InstractorWorkForDepartmentName, opt=>opt.MapFrom(src=>src.department.GetLocalized(src.department.DNameAr, src.department.DNameEn)))
               .ForMember(des=>des.InstractorManageForDepartmentName,opt=>opt.MapFrom(src=>src.departmentManger.GetLocalized(src.departmentManger.DNameAr,src.departmentManger.DNameEn)))
                .ForMember(dest => dest.Supervied,
                    opt => opt.MapFrom(src =>
                        src.Supervisor != null
                        ? src.Supervisor.GetLocalized(src.Supervisor.ENameAr, src.Supervisor.ENameEn)
                        : ""
                    ))
               .ForMember(dest => dest.Subjects,
                          opt => opt.MapFrom(src => src.Ins_Subjects));

            // Mapping من Ins_Subject لـ SubjectResponse
            CreateMap<Ins_Subject, SubjectResponse>()
                .ForMember(dest => dest.ID,opt => opt.MapFrom(src => src.SubId))
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src =>src.subject != null? src.subject.GetLocalized(src.subject.SubjectNameAr, src.subject.SubjectNameEn): string.Empty));
        }
    }
    
}
