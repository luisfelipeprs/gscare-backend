using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetAllEmployeesUseCase
{
    Task<ResponseEmployeesJson> Execute();
}
