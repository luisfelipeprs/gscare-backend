using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetAllEmployeesUseCase
{
    Task<ResponseEmployeesJson> Execute();
}
