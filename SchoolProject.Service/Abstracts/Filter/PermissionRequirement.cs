using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts.Filter
{
    public class PermissionRequirement(string Permission) : IAuthorizationRequirement
    {
        public string Permission { get; } = Permission;

    }
}
