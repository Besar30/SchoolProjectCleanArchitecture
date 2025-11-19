using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentRequestCommand:IRequest<Result<string>>
    {
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int? InsManger { get; set; }
    }
}
