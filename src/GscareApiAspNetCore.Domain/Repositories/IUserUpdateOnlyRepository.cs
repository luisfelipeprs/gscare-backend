using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IUserUpdateOnlyRepository
{
    Task<User?> GetById(long id);
    void Update(User user);
}
