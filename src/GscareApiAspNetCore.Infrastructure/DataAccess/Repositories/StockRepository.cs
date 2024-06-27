using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories
{
    internal class StockRepository : IStockReadOnlyRepository, IStockUpdateOnlyRepository, IStockWriteOnlyRepository
    {
        private readonly GsCareDbContext _dbContext;

        public StockRepository(GsCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Stock stock)
        {
            await _dbContext.Stocks.AddAsync(stock);
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

            if (result is null)
            {
                return false;
            }

            _dbContext.Stocks.Remove(result);

            return true;
        }

        public async Task<List<Stock>> GetAll()
        {
            return await _dbContext.Stocks.AsNoTracking().ToListAsync();
        }

        async Task<Stock?> IStockReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Stocks.AsNoTracking().FirstOrDefaultAsync(stock => stock.Id == id);
        }

        async Task<Stock?> IStockUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        }

        public void Update(Stock stock)
        {
            _dbContext.Stocks.Update(stock);
        }
    }
}
