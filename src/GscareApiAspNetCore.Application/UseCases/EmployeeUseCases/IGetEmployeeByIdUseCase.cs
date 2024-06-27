using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetEmployeeByIdUseCase
{
    Task<ResponseEmployeeJson> Execute(long id);
}
