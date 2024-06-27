using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
public interface IWarningUpdateOnlyRepository
{
    Task<Warning?> GetById(long id);
    void Update(Warning warning);
}
