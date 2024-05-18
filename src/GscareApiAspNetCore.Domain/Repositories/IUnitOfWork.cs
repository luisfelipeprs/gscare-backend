namespace GscareApiAspNetCore.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
