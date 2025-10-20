using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts.Filter
{
    public class HasPermissionAttribute(string Permission) : AuthorizeAttribute(Permission)
    {

    }
}
