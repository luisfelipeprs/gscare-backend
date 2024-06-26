using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IGetEmployeeByIdUseCase
{
    Task<ResponseEmployeeJson> Execute(long id);
}
