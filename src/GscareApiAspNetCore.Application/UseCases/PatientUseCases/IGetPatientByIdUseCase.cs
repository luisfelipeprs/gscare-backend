using GscareApiAspNetCore.Communication.Responses.PatientResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetPatientByIdUseCase
{
    Task<ResponsePatientJson> Execute(long id);
}
