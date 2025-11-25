using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Queries.Responses
{
    public class GetAllInstractorResponse
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Salary { get; set; }
        public string? ImageFile { get; set; }
        public string? InstractorWorkForDepartmentName { get; set; }
        public string? InstractorManageForDepartmentName { get; set; }
        public string Position { get; set; }
       // public string Supervied { get; set; }
        public List<SubjectResponse>? Subjects { get; set; }
    }

}