using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
public interface IServiceReadOnlyRepository
{
    Task<List<Service>> GetAll();
    Task<Service?> GetById(long id);
}
