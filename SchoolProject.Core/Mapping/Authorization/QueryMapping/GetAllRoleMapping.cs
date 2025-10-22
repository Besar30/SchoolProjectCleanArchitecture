using SchoolProject.Core.Features.Authrization.Queries.Results;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile
    {
        public void GetAllRoleMapping()
        {
            CreateMap<ApplicationRole, GetAllRoleResponse>();
        }
    }
}
