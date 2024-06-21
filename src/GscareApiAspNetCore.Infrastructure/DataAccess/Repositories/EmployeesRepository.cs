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
    //===============================


    
}
