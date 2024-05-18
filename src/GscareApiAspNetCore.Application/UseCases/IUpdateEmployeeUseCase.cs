using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IUpdateEmployeeUseCase
{
    Task Execute(long Id, RequestEmployeeJson request);
}
