using GscareApiAspNetCore.Communication.Responses.PatientResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetPatientsByCurrentCompanyUseCase
{
    Task<ResponsePatientsJson> Execute();
}