using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.PatientResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IRegisterPatientUseCase
{
    Task<ResponseRegisteredPatientJson> Execute(RequestPatientJson request);
}
