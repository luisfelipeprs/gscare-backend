using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IEmployeeReadOnlyRepository
{
    Task<List<Employee>> GetAll();
    Task<Employee?> GetById(long id);
}
