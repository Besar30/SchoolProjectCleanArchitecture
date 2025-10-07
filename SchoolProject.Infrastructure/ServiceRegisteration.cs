using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
        {
           services.AddIdentity<User,IdentityRole>(option=>
           {
               // Password settings.
               option.Password.RequireDigit = true;
               option.Password.RequireLowercase = true;
               option.Password.RequireNonAlphanumeric = true;
               option.Password.RequireUppercase = true;
               option.Password.RequiredLength = 6;
               option.Password.RequiredUniqueChars = 1;

               // Lockout settings.
               option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
               option.Lockout.MaxFailedAccessAttempts = 5;
               option.Lockout.AllowedForNewUsers = true;

               // User settings.
               option.User.AllowedUserNameCharacters =
               "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
               option.User.RequireUniqueEmail = false;
           }).AddEntityFrameworkStores<ApplicationDBContext>().AddEntityFrameworkStores<ApplicationDBContext>();
            return services;
        }
    }
}
