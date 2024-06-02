using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
public interface ISupplyUpdateOnlyRepository
{
    Task<Supply?> GetById(long id);
    void Update(Supply supply);
}
