using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Infrastructure.DataAccess;
using GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GscareApiAspNetCore.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeReadOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeWriteOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeUpdateOnlyRepository, EmployeesRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 35);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<GsCareDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
