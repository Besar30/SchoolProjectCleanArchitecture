using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.response
{
    public class GetSubjectByIdResponse
    {
        public int SubID { get; set; }
        public string SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public int Period { get; set; }
        public List<StudentInSubjectResponse> studentInSubject { get; set; }
        public List<DepartmentInSubjectResponse> departmentInSubject { get; set; }
        public List<InstructorInSubjectResponse> instructorInSubject { get; set; }
    }
    public class StudentInSubjectResponse
    {
        public int StudentID { get; set; }
        public string StudentName
        {
            get; set;
        }
        public int Grade { get; set; }
    
    }
    public class DepartmentInSubjectResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class InstructorInSubjectResponse
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
    }

}