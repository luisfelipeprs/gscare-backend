using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public interface IUpdateServiceUseCase
{
    Task Execute(long Id, RequestServiceJson request);
}
