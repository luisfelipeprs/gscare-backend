using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class ServiceRepository : IServiceReadOnlyRepository, IServiceWriteOnlyRepository, IServiceUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public ServiceRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Service Service)
    {
        await _dbContext.Services.AddAsync(Service);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Services.FirstOrDefaultAsync(Service => Service.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Services.Remove(result);

        return true;
    }

    public async Task<List<Service>> GetAll()
    {
        return await _dbContext.Services.AsNoTracking().ToListAsync();
        //await _dbContext.Services.Where(e => e.UserId == id)
    }

    async Task<Service?> IServiceReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Services.AsNoTracking().FirstOrDefaultAsync(Service => Service.Id == id);
    }

    async Task<Service?> IServiceUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Services.FirstOrDefaultAsync(Service => Service.Id == id);
    }

    public void Update(Service Service)
    {
        _dbContext.Services.Update(Service);
    }
}
