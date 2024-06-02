using GscareApiAspNetCore.Communication.Responses.SupplyResponses;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public interface IGetSupplyByIdUseCase
{
    Task<ResponseSupplyJson> Execute(long id);
}
