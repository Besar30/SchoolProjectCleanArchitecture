using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queires.Responses
{
    public class GetDepartmentStudentCountProcByIdResponse
    {
        public int DID {  get; set; }
        public string Name {  get; set; }
        public int StudentCount { get; set; }
    }
}
