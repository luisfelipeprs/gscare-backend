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
    async Task<Company?> ICompanyUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }
    async Task<Company?> ICompanyReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync(Company => Company.Id == id);
    }

    public async Task<List<Company>> GetAll()
    {
        return await _dbContext.Companies.AsNoTracking().ToListAsync();
    }

    public async Task Add(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
    }

    public void Update(Company company)
    {
        _dbContext.Companies.Update(company);
    }

    public async Task<bool> Delete(long id)
    {
         
        var company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        if (company == null)
            return false;

        _dbContext.Companies.Remove(company);
        return true;
    }

    // No repositório PatientRepository
    public async Task<List<Patient>> GetAllPatientsByCompanyId(long companyId)
    {
        return await _dbContext.Patients
            .Where(p => p.CurrentCompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();
    }

    // No repositório UsersRepository
    public async Task<List<Employee>> GetAllEmployeesByCompanyId(long companyId)
    {
        return await _dbContext.Employees
            .Where(e => e.CurrentCompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();
    }

}
