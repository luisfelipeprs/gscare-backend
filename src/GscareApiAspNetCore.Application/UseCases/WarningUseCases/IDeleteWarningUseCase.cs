namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public interface IDeleteWarningUseCase
{
    Task Execute(long id);
}
