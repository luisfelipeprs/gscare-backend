using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.WarningRepositories;
public interface IWarningReadOnlyRepository
{
    Task<List<Warning>> GetAll();
    Task<Warning?> GetById(long id);
}
