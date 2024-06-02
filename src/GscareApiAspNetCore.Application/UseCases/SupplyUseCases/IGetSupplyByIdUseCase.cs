using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public interface IGetSupplyByIdUseCase
{
    Task<ResponseSupplyJson> Execute(long id);
}
