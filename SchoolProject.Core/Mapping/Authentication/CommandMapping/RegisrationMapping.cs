using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Authentication
{
    public partial class AuthenticationProfile
    {
        public void RegisrationMapping()
        {
            CreateMap<RegistrationCommand,User>();
        }
    }
}
