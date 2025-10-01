using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;

namespace SchoolProject.Service
{
    public static class ModelServiceDependancy
    {
        public static IServiceCollection AddServiceDependancy(this IServiceCollection services) {
            services.AddTransient<IStudentService,StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
