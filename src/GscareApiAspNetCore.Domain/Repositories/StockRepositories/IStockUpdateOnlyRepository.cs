using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.StockRepositories;
public interface IStockUpdateOnlyRepository
{
    Task<Stock?> GetById(long id);
    void Update(Stock stock);
}