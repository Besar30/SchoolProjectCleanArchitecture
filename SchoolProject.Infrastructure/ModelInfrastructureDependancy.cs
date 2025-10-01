using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Reposatories;

namespace SchoolProject.Infrastructure
{
    public static class ModelInfrastructureDependancy
    {
        public static IServiceCollection AddInfrastructureDependancy(this IServiceCollection services) {
            services.AddTransient<IStudentRepository,StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
