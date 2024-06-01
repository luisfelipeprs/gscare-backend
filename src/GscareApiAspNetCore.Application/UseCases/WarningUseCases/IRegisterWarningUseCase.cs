using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public interface IRegisterWarningUseCase
{
    Task<ResponseRegisteredWarningJson> Execute(RequestWarningJson request);
}
