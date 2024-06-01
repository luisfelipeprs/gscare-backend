using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IWarningReadOnlyRepository
{
    Task<List<Warning>> GetAll();
    Task<Warning?> GetById(long id);
}
