using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class EmployeesRepository : IEmployeeReadOnlyRepository, IEmployeeWriteOnlyRepository, IEmployeeUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public EmployeesRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);

        if(result is null)
        {
            return false;
        }

        _dbContext.Employees.Remove(result);

        return true;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _dbContext.Employees.AsNoTracking().ToListAsync();
        //await _dbContext.Employees.Where(e => e.UserId == id)
    }

    async Task<Employee?> IEmployeeReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(employee => employee.Id == id);
    }

    async Task<Employee?> IEmployeeUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public void Update(Employee employee)
    {
        _dbContext.Employees.Update(employee);
    }
}
