using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Infrastructure.DataAccess;
using GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
using GscareApiAspNetCore.Infrastructure.Security.Tokens.Access.Generator;
using GscareApiAspNetCore.Infrastructure.Security.Tokens.Access.Validator;
using GscareApiAspNetCore.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GscareApiAspNetCore.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddLoggedUser(services);
        AddDbContext(services, configuration);
        AddTokens(services, configuration);
    }

    //  PQ DEIXEI AS CLASSES PUBLICAS????
    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeReadOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeWriteOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeUpdateOnlyRepository, EmployeesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UsersRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 35);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<GsCareDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    public static void AddTokens(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        services.AddScoped<IAccessTokenValidator>(option => new JwtTokenValidator(signingKey!));
    }

    public static void AddLoggedUser(IServiceCollection services) => services.AddScoped<ILoggedUser, LoggedUser>();
}
