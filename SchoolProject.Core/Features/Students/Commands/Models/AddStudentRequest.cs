using MediatR;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentRequest:IRequest<Result<string>>
    {
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;

        public int DID { get; set; }
    }
}