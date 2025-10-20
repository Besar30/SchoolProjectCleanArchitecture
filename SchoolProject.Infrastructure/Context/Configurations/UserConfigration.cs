using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Abstracts.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(x => x.refreshTokens)
                .WithOwner()
                .HasForeignKey("UserId");
         
            //Default data
            builder.HasData(
                    new User
                    {
                        Id = DefaultUsers.AdminId,
                        FirstName = "Plant-Project",
                        LastName = "Admin",
                        UserName = DefaultUsers.AdminUserName,
                        NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
                        Email = DefaultUsers.AdminEmail,
                        NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
                        SecurityStamp = DefaultUsers.AdminSecurityStamp,
                        ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber="01205024661",
                        PasswordHash = "AQAAAAIAAYagAAAAEES76XCzEAJzOKK3RHphtyNuJc52FtrqMqoDuSoo921MiNJ/llOGYPXIq92thIuxvg=="

                    });
        }
       
    }
}