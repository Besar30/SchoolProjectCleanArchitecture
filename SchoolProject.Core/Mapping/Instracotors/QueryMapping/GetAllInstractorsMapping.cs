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
       void GetAllInstractorsMapping()
        {
            CreateMap<Instractor, GetAllInstractorResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.GetLocalized(src.ENameAr, src.ENameEn)))
                .ForMember(des => des.ImageFile, opt => opt.MapFrom(src => src.Image))
                .ForMember(des => des.InstractorWorkForDepartmentName, opt => opt.MapFrom(src => src.department.GetLocalized(src.department.DNameAr, src.department.DNameEn)))
                .ForMember(des => des.InstractorManageForDepartmentName, opt => opt.MapFrom(src => src.departmentManger.GetLocalized(src.departmentManger.DNameAr, src.departmentManger.DNameEn)))
                .ForMember(des => des.Subjects, opt => opt.MapFrom(src => src.Ins_Subjects))
                ;
            CreateMap<Ins_Subject, SubjectResponse>()
                .ForMember(des=>des.ID,opt=>opt.MapFrom(src=>src.SubId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.subject != null ? src.subject.GetLocalized(src.subject.SubjectNameAr, src.subject.SubjectNameEn) : string.Empty));

        }
    }
}
