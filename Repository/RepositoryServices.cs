using Data.SqlServer.AppContext;
using Domain.Abstractions.Base;
using Domain.Abstractions.Departments;
using Domain.Abstractions.Employees;
using Domain.Abstractions.PerformanceReviews;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Repository.DepartmentRepositories;
using Repository.EmployeeRepositories;
using Repository.PerformanceReviewRepositories;

namespace Repository
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFacade, RepositoryFacade>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();

            return services;
        }
    }
}
