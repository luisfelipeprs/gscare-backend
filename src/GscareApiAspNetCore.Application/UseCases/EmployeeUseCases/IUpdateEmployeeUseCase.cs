using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IUpdateEmployeeUseCase
{
    Task Execute(long Id, RequestEmployeeJson request);
}
