using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
public interface ISupplyReadOnlyRepository
{
    Task<List<Supply>> GetAll();
    Task<Supply?> GetById(long id);
}
