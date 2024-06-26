using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetEmployeesByCurrentCompanyUseCase
{
    Task<ResponseEmployeesJson> Execute();
}