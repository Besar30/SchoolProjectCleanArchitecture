using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using System.Text;

namespace SchoolProject.Service
{
    public static class ModelServiceDependancy
    {
        public static IServiceCollection AddServiceDependancy(this IServiceCollection services,IConfiguration configration) {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
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
