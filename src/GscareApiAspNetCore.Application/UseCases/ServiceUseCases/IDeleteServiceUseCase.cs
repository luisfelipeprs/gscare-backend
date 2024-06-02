namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public interface IDeleteServiceUseCase
{
    Task Execute(long id);
}
