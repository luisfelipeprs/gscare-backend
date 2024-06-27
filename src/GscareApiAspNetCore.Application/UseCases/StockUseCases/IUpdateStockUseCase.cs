using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public interface IUpdateStockUseCase
{
    Task Execute(long id, RequestStockJson request);
}
