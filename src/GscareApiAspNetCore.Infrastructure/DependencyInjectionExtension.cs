using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
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

        // DailyReport
        services.AddScoped<IDailyReportReadOnlyRepository, DailyReportRepository>();
        services.AddScoped<IDailyReportWriteOnlyRepository, DailyReportRepository>();
        services.AddScoped<IDailyReportUpdateOnlyRepository, DailyReportRepository>();

        // Service
        services.AddScoped<IServiceReadOnlyRepository, ServiceRepository>();
        services.AddScoped<IServiceWriteOnlyRepository, ServiceRepository>();
        services.AddScoped<IServiceUpdateOnlyRepository, ServiceRepository>();

        // Supply
        services.AddScoped<ISupplyReadOnlyRepository, SupplyRepository>();
        services.AddScoped<ISupplyWriteOnlyRepository, SupplyRepository>();
        services.AddScoped<ISupplyUpdateOnlyRepository, SupplyRepository>();

        // Medicament
        services.AddScoped<IMedicamentReadOnlyRepository, MedicamentRepository>();
        services.AddScoped<IMedicamentWriteOnlyRepository, MedicamentRepository>();
        services.AddScoped<IMedicamentUpdateOnlyRepository, MedicamentRepository>();

        // Company
        services.AddScoped<ICompanyReadOnlyRepository, CompaniesRepository>();
        services.AddScoped<ICompanyWriteOnlyRepository, CompaniesRepository>();
        services.AddScoped<ICompanyUpdateOnlyRepository, CompaniesRepository>();

        // Employee
        services.AddScoped<IEmployeeReadOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeWriteOnlyRepository, EmployeesRepository>();
        services.AddScoped<IEmployeeUpdateOnlyRepository, EmployeesRepository>();

        // Patient
        services.AddScoped<IPatientReadOnlyRepository, PatientRepository>();
        services.AddScoped<IPatientWriteOnlyRepository, PatientRepository>();
        services.AddScoped<IPatientUpdateOnlyRepository, PatientRepository>();

        // User
        services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UsersRepository>();

        // Warning
        services.AddScoped<IWarningReadOnlyRepository, WarningsRepository>();
        services.AddScoped<IWarningWriteOnlyRepository, WarningsRepository>();
        services.AddScoped<IWarningUpdateOnlyRepository, WarningsRepository>();
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
