using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
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
        CreateMap<RequestEmployeeJson, Employee>();
        CreateMap<RequestUserJson, User>();
        CreateMap<RequestPatientJson, Patient>();
    }

    private void EntityToResponse()
    {
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
