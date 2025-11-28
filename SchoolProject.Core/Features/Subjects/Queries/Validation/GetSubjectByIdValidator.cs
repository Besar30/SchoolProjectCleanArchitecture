using FluentValidation;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Validation
{
    public class GetSubjectByIdValidator:AbstractValidator<GetSubjectByIdRequestQuery>
    {
        public GetSubjectByIdValidator() { 
            RuleFor(x=>x.Id).NotNull().NotEmpty();
        }
    }
}
