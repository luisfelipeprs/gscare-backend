using GscareApiAspNetCore.Communication.Responses.StockResponses;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public interface IGetStockByIdUseCase
{
    Task<ResponseStockJson> Execute(long id);
}
