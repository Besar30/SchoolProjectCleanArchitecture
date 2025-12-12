using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entites;
namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void MapEditStudentRequest()
        {
            CreateMap<EditStudentRequest, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmetName))
                .ForMember(dest => dest.StudentID, opt => opt.Ignore());

        }
    }
}
