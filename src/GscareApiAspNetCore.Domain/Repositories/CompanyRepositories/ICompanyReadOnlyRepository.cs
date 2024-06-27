using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.CompanyRepositories;
public interface ICompanyReadOnlyRepository
{
    Task<List<Company>> GetAll();
    Task<Company?> GetById(long id);
}
