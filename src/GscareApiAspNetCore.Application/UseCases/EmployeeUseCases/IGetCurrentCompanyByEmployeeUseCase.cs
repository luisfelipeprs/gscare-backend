using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetCurrentCompanyByEmployeeUseCase
{
    Task<ResponseCompanyJson> Execute();
}
