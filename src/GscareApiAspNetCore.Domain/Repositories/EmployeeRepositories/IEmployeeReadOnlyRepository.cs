using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
public interface IEmployeeReadOnlyRepository
{
    Task<List<Employee>> GetEmployeesByCompanyId(long companyId);
    Task<List<Employee>> GetAll();
    Task<Employee?> GetById(long id);
    Task<Company?> GetCurrentCompanyByEmployee(long currentCompanyId);
}
