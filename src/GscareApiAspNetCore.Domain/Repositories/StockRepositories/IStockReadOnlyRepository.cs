using GscareApiAspNetCore.Domain.Entities;
using System.ComponentModel.Design;

namespace GscareApiAspNetCore.Domain.Repositories.StockRepositories;
public interface IStockReadOnlyRepository
{
    Task<List<Stock>> GetAll(long companyId);
    Task<Stock?> GetById(long id);
}