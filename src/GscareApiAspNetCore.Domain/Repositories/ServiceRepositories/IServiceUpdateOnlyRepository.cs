using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
public interface IServiceUpdateOnlyRepository
{
    Task<Service?> GetById(long id);
    void Update(Service service);
}
