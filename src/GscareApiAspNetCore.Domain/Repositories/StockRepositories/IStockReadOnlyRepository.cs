using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.StockRepositories;
public interface IStockReadOnlyRepository
{
    Task<List<Stock>> GetAll();
    Task<Stock?> GetById(long id);
}