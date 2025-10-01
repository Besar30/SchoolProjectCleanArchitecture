using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queires.Responses
{
    public class GetDepartmentByIdResponse
    {
        public int DID { get; set; }
        public string Name { get; set; }
        
        public string ManagerName { get; set; }
        public List<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }
    }
    public class StudentResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
