using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entites.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Reposatories;
using SchoolProject.Infrastructure.Reposatories.Procedures;
using SchoolProject.Infrastructure.Reposatories.Views;

namespace SchoolProject.Infrastructure
{
    public static class ModelInfrastructureDependancy
    {
        public static IServiceCollection AddInfrastructureDependancy(this IServiceCollection services) {
            services.AddTransient<IStudentRepository,StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstractorRepository, InstractorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepository>();
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();
            services.AddTransient<IStudentSubjectRepository, StudentSubjectRepository>();

            return services;
        }
    }
}
