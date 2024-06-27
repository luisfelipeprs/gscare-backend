using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetEmployeesByCurrentCompanyUseCase
{
    Task<ResponseEmployeesJson> Execute();
}