using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.UserRepositories;
public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
