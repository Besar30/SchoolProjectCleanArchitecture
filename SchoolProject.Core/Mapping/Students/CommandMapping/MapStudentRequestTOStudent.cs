using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void MapStudentRequestTOstudent()
        {
           CreateMap<AddStudentRequest,Student>()
                .ForMember(des=>des.DID, opt=>opt.MapFrom(src=>src.DID));
        }
    }
}
