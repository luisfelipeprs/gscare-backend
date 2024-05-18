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
    }

    private void EntityToResponse()
    {
        CreateMap<Employee, ResponseRegisteredEmployeeJson>();
        CreateMap<Employee, ResponseShortEmployeeJson>();
        CreateMap<Employee, ResponseEmployeeJson>();
    }
}
