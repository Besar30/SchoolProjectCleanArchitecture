using SchoolProject.Core.Features.Subjects.Queries.response;
using SchoolProject.Data.Entites;

namespace SchoolProject.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        void GetSubjectByIdQueryMapping()
        {
            CreateMap<Subject, GetSubjectByIdResponse>()
                .ForMember(des=>des.studentInSubject,opt=>opt.MapFrom(src=>src.StudentsSubjects))
                .ForMember(des=>des.departmentInSubject,opt=>opt.MapFrom(src=>src.DepartmetsSubjects))
                .ForMember(des=>des.instructorInSubject, opt=>opt.MapFrom(src=>src.InsSubjects));

            CreateMap<StudentSubject, StudentInSubjectResponse>()
                .ForMember(des => des.StudentName, opt => opt.MapFrom(src => src.Student.GetLocalized(src.Student.NameAr, src.Student.NameEn)))
                .ForMember(des => des.StudentID, opt => opt.MapFrom(src => src.Student.StudentID))
                .ForMember(des => des.Grade, opt => opt.MapFrom(src => src.Grade));

            CreateMap<DepartmetSubject, DepartmentInSubjectResponse>()
                .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DID))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.GetLocalized(src.Department.DNameAr, src.Department.DNameEn)));

            CreateMap<Ins_Subject, InstructorInSubjectResponse>()
                .ForMember(des => des.InstructorId, opt => opt.MapFrom(src => src.InsId))
                .ForMember(des => des.InstructorName, opt => opt.MapFrom(src => src.instractor.GetLocalized(src.instractor.ENameAr, src.instractor.ENameEn)));
        }
    }
}
