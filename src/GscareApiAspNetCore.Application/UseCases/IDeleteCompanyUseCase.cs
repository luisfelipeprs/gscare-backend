namespace GscareApiAspNetCore.Application.UseCases;
public interface IDeleteCompanyUseCase
{
    Task Execute(long id);
}
