using SchoolProject.Core.Features.Student_Subject.Commands.Models;
using SchoolProject.Data.Entites;
namespace SchoolProject.Core.Mapping.StudentSubjects
{
    public partial class StudentSubjectProfile
    {
        void AddStudentSubjectMapping()
        {
               
                 CreateMap<AddStudentSubjectCommand, StudentSubject>()
                 .ForMember(des => des.StudID, opt => opt.MapFrom(src => src.StudentID))
                 .ForMember(des => des.SubID, opt => opt.MapFrom(src => src.SubjectID))
                 .ForMember(des => des.Grade, opt => opt.MapFrom(src => src.Grade));
        }
    }
}
