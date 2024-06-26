using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetPatientsByCurrentCompanyUseCase
{
    Task<ResponsePatientsJson> Execute();
}