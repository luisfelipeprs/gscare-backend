using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetAllPatientsUseCase
{
    Task<ResponsePatientsJson> Execute();
}
