using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.StockResponses;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public interface IRegisterStockUseCase
{
    Task<ResponseRegisteredStockJson> Execute(RequestStockJson request);
}
