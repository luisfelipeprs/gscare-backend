using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.ServiceReponses;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public interface IRegisterServiceUseCase
{
    Task<ResponseRegisteredServiceJson> Execute(RequestServiceJson request);
}
