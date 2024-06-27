using GscareApiAspNetCore.Communication.Responses.StockResponses;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public interface IGetAllStocksUseCase
{
    Task<ResponseStocksJson> Execute();
}
