using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
