using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IUpdatePatientUseCase
{
    Task Execute(long Id, RequestPatientJson request);
}
