using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class WarningsRepository : IWarningReadOnlyRepository, IWarningUpdateOnlyRepository, IWarningWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public WarningsRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Warning warning)
    {
        await _dbContext.Warnings.AddAsync(warning);
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

    public async Task<List<Warning>> GetAll(long companyId)
    {
        return await _dbContext.Warnings
            .Where(warning => warning.CompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();
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

