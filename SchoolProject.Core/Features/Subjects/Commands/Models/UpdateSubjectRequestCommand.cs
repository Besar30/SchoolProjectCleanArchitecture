
using MediatR;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class UpdateSubjectRequestCommand:IRequest<Result<string>>
    {
        public int SubID { get; set; }
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public int? Period { get; set; }
    }
}
