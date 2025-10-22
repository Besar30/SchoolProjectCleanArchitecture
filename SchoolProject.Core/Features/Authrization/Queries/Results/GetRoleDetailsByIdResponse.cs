using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Queries.Results
{
    public class GetRoleDetailsByIdResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}
