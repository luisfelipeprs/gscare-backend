using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    public Task<Employee> Employee();
    public Task<User> User();
}
