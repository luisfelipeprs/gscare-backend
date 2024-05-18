using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IRegisterEmployeeUseCase
{
    Task<ResponseRegisteredEmployeeJson> Execute(RequestEmployeeJson request);
}
