using GscareApiAspNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Domain.Repositories.StockRepositories;
public interface IStockWriteOnlyRepository
{
    Task Add(Stock stock);
    /// <summary>
    /// This function returns TRUE if the deletion was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}