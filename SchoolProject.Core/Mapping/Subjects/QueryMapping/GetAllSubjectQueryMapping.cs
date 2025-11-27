using SchoolProject.Core.Features.Subjects.Queries.response;
using SchoolProject.Core.pagination;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        void GetAllSubjectQueryMapping()
        {
            CreateMap<Subject, GetAllSubjectResponse>();
        }
    }
}
