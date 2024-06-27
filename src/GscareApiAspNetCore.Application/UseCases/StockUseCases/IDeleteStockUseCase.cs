namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public interface IDeleteStockUseCase
{
    Task Execute(long id);
}
