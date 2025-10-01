using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Absractions
{
    public record Error(string Code, string Discription, int? StatusCode)
    {
        public static readonly Error None = new Error(string.Empty, string.Empty, null);
    }
}
