using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.CompanyRepositories;
public interface ICompanyUpdateOnlyRepository
{
    Task<Company?> GetById(long id);
    void Update(Company company);
}
