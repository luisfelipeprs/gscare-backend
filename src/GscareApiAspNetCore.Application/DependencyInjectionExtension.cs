using GscareApiAspNetCore.Application.AutoMapper;
using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
using GscareApiAspNetCore.Application.UseCases.WarningUseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GscareApiAspNetCore.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        //Medicament
        services.AddScoped<IRegisterMedicamentUseCase, RegisterMedicamentUseCase>();
        services.AddScoped<IGetAllMedicamentsUseCase, GetAllMedicamentsUseCase>();
        services.AddScoped<IGetMedicamentByIdUseCase, GetMedicamentByIdUseCase>();
        services.AddScoped<IDeleteMedicamentUseCase, DeleteMedicamentUseCase>();
        services.AddScoped<IUpdateMedicamentUseCase, UpdateMedicamentUseCase>();

        //Warning
        services.AddScoped<IRegisterWarningUseCase, RegisterWarningUseCase>();
        services.AddScoped<IGetAllWarningsUseCase, GetAllWarningsUseCase>();
        services.AddScoped<IGetWarningByIdUseCase, GetWarningByIdUseCase>();
        services.AddScoped<IDeleteWarningUseCase, DeleteWarningUseCase>();
        services.AddScoped<IUpdateWarningUseCase, UpdateWarningUseCase>();

        //Company
        services.AddScoped<IRegisterCompanyUseCase, RegisterCompanyUseCase>();
        services.AddScoped<IGetAllCompaniesUseCase, GetAllCompaniesUseCase>();
        services.AddScoped<IGetCompanyByIdUseCase, GetCompanyByIdUseCase>();
        services.AddScoped<IDeleteCompanyUseCase, DeleteCompanyUseCase>();
        services.AddScoped<IUpdateCompanyUseCase, UpdateCompanyUseCase>();

        //Employee
        services.AddScoped<IRegisterEmployeeUseCase, RegisterEmployeeUseCase>();
        services.AddScoped<IGetAllEmployeesUseCase, GetAllEmployeesUseCase>();
        services.AddScoped<IGetEmployeeByIdUseCase, GetEmployeeByIdUseCase>();
        services.AddScoped<IDeleteEmployeeUseCase, DeleteEmployeeUseCase>();
        services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();

        //Patient
        services.AddScoped<IRegisterPatientUseCase, RegisterPatientUseCase>();
        services.AddScoped<IGetAllPatientsUseCase, GetAllPatientsUseCase>();
        services.AddScoped<IGetPatientByIdUseCase, GetPatientByIdUseCase>();
        services.AddScoped<IDeletePatientUseCase, DeletePatientUseCase>();
        services.AddScoped<IUpdatePatientUseCase, UpdatePatientUseCase>();

        //User
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
    }
}
