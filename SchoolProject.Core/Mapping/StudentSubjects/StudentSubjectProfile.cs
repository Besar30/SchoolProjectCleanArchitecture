using AutoMapper;
namespace SchoolProject.Core.Mapping.StudentSubjects
{
    public partial class StudentSubjectProfile:Profile
    {
       public StudentSubjectProfile() {
            AddStudentSubjectMapping();
            UpdateStudentSubjectMapping();
        }   
    }
}
