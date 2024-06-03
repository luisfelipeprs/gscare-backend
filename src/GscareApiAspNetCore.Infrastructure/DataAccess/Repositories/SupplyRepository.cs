using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class SupplyRepository : ISupplyReadOnlyRepository, ISupplyUpdateOnlyRepository, ISupplyWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public SupplyRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Supply Supply)
    {
        await _dbContext.Supplies.AddAsync(Supply);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Supplies.FirstOrDefaultAsync(Supply => Supply.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Supplies.Remove(result);

        return true;
    }

    public async Task<List<Supply>> GetAll()
    {
        return await _dbContext.Supplies.AsNoTracking().ToListAsync();
        //await _dbContext.Supplies.Where(e => e.UserId == id)
    }

    async Task<Supply?> ISupplyReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Supplies.AsNoTracking().FirstOrDefaultAsync(Supply => Supply.Id == id);
    }

    async Task<Supply?> ISupplyUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Supplies.FirstOrDefaultAsync(Supply => Supply.Id == id);
    }

    public void Update(Supply Supply)
    {
        _dbContext.Supplies.Update(Supply);
    }
}
