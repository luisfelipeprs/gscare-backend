using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
using GscareApiAspNetCore.Communication.Responses.ServiceReponses;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestUserJson, User>();
        CreateMap<RequestEmployeeJson, Employee>();
        CreateMap<RequestPatientJson, Patient>();
        CreateMap<RequestCompanyJson, Company>();
        CreateMap<RequestWarningJson, Warning>();
        CreateMap<RequestMedicamentJson, Medicament>();
        CreateMap<RequestSupplyJson, Supply>();
        CreateMap<RequestServiceJson, Service>();
        CreateMap<RequestDailyReportJson, DailyReport>();
    }

    private void EntityToResponse()
    {

        //DailyReport
        CreateMap<DailyReport, ResponseRegisteredDailyReportJson>();
        CreateMap<DailyReport, ResponseShortDailyReportJson>();
        CreateMap<DailyReport, ResponseDailyReportJson>();

        //Service
        CreateMap<Service, ResponseRegisteredServiceJson>();
        CreateMap<Service, ResponseShortServiceJson>();
        CreateMap<Service, ResponseServiceJson>();

        //Supply 
        CreateMap<Supply, ResponseRegisteredSupplyJson>();
        CreateMap<Supply, ResponseShortSupplyJson>();
        CreateMap<Supply, ResponseSupplyJson>();

        //Medicament 
        CreateMap<Medicament, ResponseRegisteredMedicamentJson>();
        CreateMap<Medicament, ResponseShortMedicamentJson>();
        CreateMap<Medicament, ResponseMedicamentJson>();

        //Warning 
        CreateMap<Warning, ResponseRegisteredWarningJson>();
        CreateMap<Warning, ResponseShortWarningJson>();
        CreateMap<Warning, ResponseWarningJson>();

        //Patient 
        CreateMap<Company, ResponseRegisteredCompanyJson>();
        CreateMap<Company, ResponseShortCompanyJson>();
        CreateMap<Company, ResponseCompanyJson>();

        //Patient 
        CreateMap<Patient, ResponseRegisteredPatientJson>();
        CreateMap<Patient, ResponseShortPatientJson>();
        CreateMap<Patient, ResponsePatientJson>();

        //Employee
        CreateMap<Employee, ResponseRegisteredEmployeeJson>();
        CreateMap<Employee, ResponseShortEmployeeJson>();
        CreateMap<Employee, ResponseEmployeeJson>();

        //User
        CreateMap<User, ResponseRegisteredUserJson>();
        CreateMap<User, ResponseShortUserJson>();
        CreateMap<User, ResponseUserJson>();
        CreateMap<User, ResponseUserProfileJson>();
    }
}
