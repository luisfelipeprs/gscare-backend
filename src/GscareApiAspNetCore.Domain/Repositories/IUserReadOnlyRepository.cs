using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IUserReadOnlyRepository
{
    Task<User?> GetById(long id);
    Task<User?> GetByEmail(string email);
}
