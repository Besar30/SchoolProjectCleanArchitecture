using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Queries.Results
{
    public class GetAllRoleResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
