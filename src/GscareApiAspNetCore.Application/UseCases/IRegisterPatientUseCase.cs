using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IRegisterPatientUseCase
{
    Task<ResponseRegisteredPatientJson> Execute(RequestPatientJson request);
}
