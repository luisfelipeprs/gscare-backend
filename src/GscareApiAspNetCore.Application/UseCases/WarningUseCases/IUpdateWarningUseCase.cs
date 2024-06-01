using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public interface IUpdateWarningUseCase
{
    Task Execute(long Id, RequestWarningJson request);
}
