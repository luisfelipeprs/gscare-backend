using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public interface IRegisterSupplyUseCase
{
    Task<ResponseRegisteredSupplyJson> Execute(RequestSupplyJson request);
}
