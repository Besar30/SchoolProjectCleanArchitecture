using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Abstracts.Const
{
    public static class DefaultRoles
    {
        public const string Admin = nameof(Admin);
        public const string AdminRoleId = "0195442f-5b32-7334-9a35-d43ff70d3aa9";
        public const string AdminRoleConcurrencyStamp = "0195442f-5b32-761a-b2ee-cfca69434828";


        public const string Member = nameof(Member);
        public const string MemberRoleId = "0195442f-5b32-7b00-a097-61b7c3baec76";
        public const string MemberRoleConcurrencyStamp = "0195442f-5b32-7bfc-8b9c-18f34c1d2eea";
    }
}
