using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class EditStudentRequest:IRequest<Result<string>>
    {
        public int Id{ get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string? phone { get; set; } = string.Empty;

        public int DepartmetName { get; set; }
    }
}
