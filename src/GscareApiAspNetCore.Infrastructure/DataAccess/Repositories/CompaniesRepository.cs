using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class CompaniesRepository : ICompanyReadOnlyRepository, ICompanyUpdateOnlyRepository, ICompanyWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public CompaniesRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Company Company)
    {
        await _dbContext.Companies.AddAsync(Company);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Companies.FirstOrDefaultAsync(Company => Company.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Companies.Remove(result);

        return true;
    }

    public async Task<List<Company>> GetAll()
    {
        return await _dbContext.Companies.AsNoTracking().ToListAsync();
        //await _dbContext.Companys.Where(e => e.UserId == id)
    }

    async Task<Company?> ICompanyReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync(Company => Company.Id == id);
    }

    async Task<Company?> ICompanyUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(Company => Company.Id == id);
    }

    public void Update(Company Company)
    {
        _dbContext.Companies.Update(Company);
    }
}
