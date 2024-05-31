using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface ICompanyUpdateOnlyRepository
{
    Task<Company?> GetById(long id);
    void Update(Company company);
}
