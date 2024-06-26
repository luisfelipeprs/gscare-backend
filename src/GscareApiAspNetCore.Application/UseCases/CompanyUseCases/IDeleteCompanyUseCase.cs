namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IDeleteCompanyUseCase
{
    Task Execute(long id);
}
