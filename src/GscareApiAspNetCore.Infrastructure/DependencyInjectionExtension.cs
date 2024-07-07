using FluentMigrator.Runner;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using GscareApiAspNetCore.Domain.Repositories.CompanyRepositories;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Infrastructure.DataAccess;
using GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
using GscareApiAspNetCore.Infrastructure.Extensions;
using GscareApiAspNetCore.Infrastructure.Security.Tokens.Access.Generator;
using GscareApiAspNetCore.Infrastructure.Security.Tokens.Access.Validator;
using GscareApiAspNetCore.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace GscareApiAspNetCore.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddLoggedUser(services);
        AddDbContext(services, configuration);
        AddTokens(services, configuration);
        AddFluentMigrator_MySql(services, configuration);
    }

    //  PQ DEIXEI AS CLASSES PUBLICAS????
    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Document
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        // DailyReport
        services.AddScoped<IDailyReportReadOnlyRepository, DailyReportRepository>();
        services.AddScoped<IDailyReportWriteOnlyRepository, DailyReportRepository>();
        services.AddScoped<IDailyReportUpdateOnlyRepository, DailyReportRepository>();

        // Supply
        services.AddScoped<ISupplyReadOnlyRepository, SupplyRepository>();
        services.AddScoped<ISupplyWriteOnlyRepository, SupplyRepository>();
        services.AddScoped<ISupplyUpdateOnlyRepository, SupplyRepository>();

        // Stock
        services.AddScoped<IStockReadOnlyRepository, StockRepository>();
        services.AddScoped<IStockWriteOnlyRepository, StockRepository>();
        services.AddScoped<IStockUpdateOnlyRepository, StockRepository>();

        // Stock
        services.AddScoped<IAppointmentReadOnlyRepository, AppointmentRepository>();
        services.AddScoped<IAppointmentWriteOnlyRepository, AppointmentRepository>();
        services.AddScoped<IAppointmentUpdateOnlyRepository, AppointmentRepository>();

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
        var connectionString = configuration.ConnectionString();

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

    private static void AddFluentMigrator_MySql(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();

        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options
            .AddMySql8()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.Load("GscareApiAspNetCore.Infrastructure")).For.All();
        });
    }
}
