using MediatR;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Core.Features.Student_Subject.Commands.Models
{
    public class AddStudentSubjectCommand:IRequest<Result<string>>
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public decimal? Grade { get; set; }

    }
}
