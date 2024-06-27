using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class EmployeesRepository : IEmployeeReadOnlyRepository, IEmployeeWriteOnlyRepository, IEmployeeUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public EmployeesRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // No repositório UsersRepository
    public async Task AssociateEmployeeWithCompany(long employeeId, long companyId)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        if (employee == null)
        {
            throw new ArgumentException("Employee not found", nameof(employeeId));
        }

        var company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new ArgumentException("Company not found", nameof(companyId));
        }

        employee.CurrentCompanyId = companyId;
        employee.CurrentCompany = company;

        await _dbContext.SaveChangesAsync();
    }
    // No repositório UsersRepository
    public async Task DisassociateEmployeeFromCompany(long employeeId)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        if (employee == null)
        {
            throw new ArgumentException("Employee not found", nameof(employeeId));
        }

        employee.CurrentCompanyId = null;
        employee.CurrentCompany = null;

        await _dbContext.SaveChangesAsync();
    }


    async Task<Employee?> IEmployeeReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(employee => employee.Id == id);
    }

    async Task<Employee?> IEmployeeUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _dbContext.Employees.AsNoTracking().ToListAsync();
    }

    public async Task Add(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
    }

    public void Update(Employee employee)
    {
        _dbContext.Employees.Update(employee);
    }

    public async Task<bool> Delete(long id)
    {
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (employee == null)
            return false;

        _dbContext.Employees.Remove(employee);
        return true;
    }

    public async Task<List<Employee>> GetEmployeesByCompanyId(long companyId)
    {
        return await _dbContext.Employees
            .Where(e => e.CurrentCompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Company?> GetCurrentCompanyByEmployee(long currentCompanyId)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == currentCompanyId);
    }
}
