using GscareApiAspNetCore.Communication.Responses.PatientResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetAllPatientsUseCase
{
    Task<ResponsePatientsJson> Execute();
}
