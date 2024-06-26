namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IDeleteEmployeeUseCase
{
    Task Execute(long id);
}
