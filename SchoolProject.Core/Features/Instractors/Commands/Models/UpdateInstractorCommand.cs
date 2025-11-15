using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Commands.Models
{
    public class UpdateInstractorCommand:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public string ENameAr { get; set; }
        public string ENameEn { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int? DID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
