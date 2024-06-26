using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetPatientByIdUseCase
{
    Task<ResponsePatientJson> Execute(long id);
}
