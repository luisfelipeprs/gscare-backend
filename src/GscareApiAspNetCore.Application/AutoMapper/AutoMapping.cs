using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
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
    }

    private void EntityToResponse()
    {

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
