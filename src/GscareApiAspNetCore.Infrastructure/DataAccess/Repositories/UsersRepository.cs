using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public UsersRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    async Task<User?> IUserReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(employee => employee.Id == id);
    }

    async Task<User?> IUserUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
