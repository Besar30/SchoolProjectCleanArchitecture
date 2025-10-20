using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Abstracts.Filter;
using SchoolProject.Service.Implementation;
using System.Net;
using System.Text;

namespace SchoolProject.Service
{
    public static class ModelServiceDependancy
    {
        public static IServiceCollection AddServiceDependancy(this IServiceCollection services,IConfiguration configration) {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthrizationServices, AuthrizationServices>();
            services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddSingleton<IJwtProvider, JwtProvider>();
          //  services.Configure<JwtOptions>(configration.GetSection(JwtOptions.NameSection));
            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.NameSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            return services;
         }
    }
}
