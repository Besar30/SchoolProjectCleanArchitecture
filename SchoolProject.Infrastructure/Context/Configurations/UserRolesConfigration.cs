using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Infrastructure.Abstracts.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class UserRolesConfigration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     UserId = DefaultUsers.AdminId,
                     RoleId = DefaultRoles.AdminRoleId
                 }
                );
        }
    }
}
