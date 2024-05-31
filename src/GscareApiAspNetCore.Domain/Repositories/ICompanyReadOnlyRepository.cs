using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface ICompanyReadOnlyRepository
{
    Task<List<Company>> GetAll();
    Task<Company?> GetById(long id);
}
