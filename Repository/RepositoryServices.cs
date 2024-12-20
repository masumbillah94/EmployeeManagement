using Data.SqlServer.AppContext;
using Domain.Abstractions.Base;
using Domain.Abstractions.HRM;
using Microsoft.Extensions.DependencyInjection;
using Repository.EfCore.Base;
using Repository.EmployeeRepositories;

namespace Repository
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFacade, RepositoryFacade>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
