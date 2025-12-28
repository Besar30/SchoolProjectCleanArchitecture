
using SchoolProject.Core.Features.Student_Subject.Commands.Models;
using SchoolProject.Data.Entites;

namespace SchoolProject.Core.Mapping.StudentSubjects
{
    public partial class StudentSubjectProfile
    {
       public void UpdateStudentSubjectMapping()
        {
            CreateMap<UpdateStudentSubjectCommand, StudentSubject>();
        }
    }
}
