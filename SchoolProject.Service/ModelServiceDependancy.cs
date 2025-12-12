using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Abstracts.Filter;
using SchoolProject.Service.AuthServices.Implementations;
using SchoolProject.Service.AuthServices.Interfaces;
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

            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ICurrentUserServices, CurrentUserServices>();

            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IInstractorService, InstractorService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IStudentSubjectServices , StudentSubjectServices>();
            services.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            //  services.Configure<JwtOptions>(configration.GetSection(JwtOptions.NameSection));
            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.NameSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            services.AddOptions<EmailBinding>()
                .BindConfiguration(EmailBinding.NameSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            return services;
         }
    }
}
