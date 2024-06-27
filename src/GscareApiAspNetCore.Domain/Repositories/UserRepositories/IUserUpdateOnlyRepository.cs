using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.UserRepositories;
public interface IUserUpdateOnlyRepository
{
    Task<User?> GetById(long id);
    void Update(User user);
}
