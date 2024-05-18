using GscareApiAspNetCore.Domain.Repositories;

namespace GscareApiAspNetCore.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly GsCareDbContext _dbContext;

    public UnitOfWork(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
