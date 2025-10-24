using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Authentication
{
    public partial class AuthenticationProfile:Profile
    {
        public AuthenticationProfile() {
            RegisrationMapping();
        }
    }
}
