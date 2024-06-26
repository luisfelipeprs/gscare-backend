using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IUpdatePatientUseCase
{
    Task Execute(long Id, RequestPatientJson request);
}
