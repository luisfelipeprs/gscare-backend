using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class WarningsRepository : IWarningReadOnlyRepository, IWarningUpdateOnlyRepository, IWarningWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public WarningsRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Warning Warning)
    {
        await _dbContext.Warnings.AddAsync(Warning);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Warnings.FirstOrDefaultAsync(Warning => Warning.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Warnings.Remove(result);

        return true;
    }

    public async Task<List<Warning>> GetAll()
    {
        return await _dbContext.Warnings.AsNoTracking().ToListAsync();
        //await _dbContext.Warnings.Where(e => e.UserId == id)
    }

    async Task<Warning?> IWarningReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Warnings.AsNoTracking().FirstOrDefaultAsync(Warning => Warning.Id == id);
    }

    async Task<Warning?> IWarningUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Warnings.FirstOrDefaultAsync(Warning => Warning.Id == id);
    }

    public void Update(Warning Warning)
    {
        _dbContext.Warnings.Update(Warning);
    }
}
