using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
public interface IEmployeeUpdateOnlyRepository
{
    Task<Employee?> GetById(long id);
    void Update(Employee employee);
    Task AssociateEmployeeWithCompany(long employeeId, long companyId);
    Task DisassociateEmployeeFromCompany(long employeeId);
}
