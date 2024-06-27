using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IRegisterEmployeeUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestEmployeeJson request);
}
