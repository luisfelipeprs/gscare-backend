using GscareApiAspNetCore.Application.AutoMapper;
using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Application.UseCases.AppointmentUseCases;
using GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
using GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
using GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
using GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
using GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
using GscareApiAspNetCore.Application.UseCases.PatientUseCases;
using GscareApiAspNetCore.Application.UseCases.StockUseCases;
using GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
using GscareApiAspNetCore.Application.UseCases.UserUseCases;
using GscareApiAspNetCore.Application.UseCases.WarningUseCases;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
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

        //Document
        services.AddScoped<IUploadDocumentUseCase, UploadDocumentUseCase>();
        services.AddScoped<IGetDocumentUseCase, GetDocumentUseCase>();

        //DailyReports
        services.AddScoped<IRegisterDailyReportUseCase, RegisterDailyReportUseCase>();
        services.AddScoped<IGetAllDailyReportsUseCase, GetAllDailyReportsUseCase>();
        services.AddScoped<IGetDailyReportByIdUseCase, GetDailyReportByIdUseCase>();
        services.AddScoped<IDeleteDailyReportUseCase, DeleteDailyReportUseCase>();
        services.AddScoped<IUpdateDailyReportUseCase, UpdateDailyReportUseCase>();

        //Supply
        services.AddScoped<IRegisterSupplyUseCase, RegisterSupplyUseCase>();
        services.AddScoped<IGetAllSuppliesUseCase, GetAllSuppliesUseCase>();
        services.AddScoped<IGetSupplyByIdUseCase, GetSupplyByIdUseCase>();
        services.AddScoped<IDeleteSupplyUseCase, DeleteSupplyUseCase>();
        services.AddScoped<IUpdateSupplyUseCase, UpdateSupplyUseCase>();

        //Stock
        services.AddScoped<IRegisterStockUseCase, RegisterStockUseCase>();
        services.AddScoped<IGetAllStocksUseCase, GetAllStocksUseCase>();
        services.AddScoped<IGetStockByIdUseCase, GetStockByIdUseCase>();
        services.AddScoped<IDeleteStockUseCase, DeleteStockUseCase>();
        services.AddScoped<IUpdateStockUseCase, UpdateStockUseCase>();

        //Appointment
        services.AddScoped<IRegisterAppointmentUseCase, RegisterAppointmentUseCase>();
        services.AddScoped<IGetAllAppointmentsUseCase, GetAllAppointmentsUseCase>();
        services.AddScoped<IGetAppointmentByIdUseCase, GetAppointmentByIdUseCase>();
        services.AddScoped<IDeleteAppointmentUseCase, DeleteAppointmentUseCase>();
        services.AddScoped<IUpdateAppointmentUseCase, UpdateAppointmentUseCase>();

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
        services.AddScoped<IGetCurrentCompanyByEmployeeUseCase, GetCurrentCompanyByEmployeeUseCase>();
        services.AddScoped<IAssociateEmployeeWithCompanyUseCase, AssociateEmployeeWithCompanyUseCase>();
        services.AddScoped<IDisassociateEmployeeFromCompanyUseCase, DisassociateEmployeeFromCompanyUseCase>();
        services.AddScoped<IGetEmployeesByCurrentCompanyUseCase, GetEmployeesByCurrentCompanyUseCase>();

        //Patient
        services.AddScoped<IRegisterPatientUseCase, RegisterPatientUseCase>();
        services.AddScoped<IGetAllPatientsUseCase, GetAllPatientsUseCase>();
        services.AddScoped<IGetPatientByIdUseCase, GetPatientByIdUseCase>();
        services.AddScoped<IDeletePatientUseCase, DeletePatientUseCase>();
        services.AddScoped<IUpdatePatientUseCase, UpdatePatientUseCase>();
        services.AddScoped<IGetCurrentCompanyByPatientUseCase, GetCurrentCompanyByPatientUseCase>();
        services.AddScoped<IAssociatePatientWithCompanyUseCase, AssociatePatientWithCompanyUseCase>();
        services.AddScoped<IDisassociatePatientFromCompanyUseCase, DisassociatePatientFromCompanyUseCase>();
        services.AddScoped<IGetPatientsByCurrentCompanyUseCase, GetPatientsByCurrentCompanyUseCase>();

        //User
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
    }
}
