namespace GscareApiAspNetCore.Application.UseCases;
public interface IDeletePatientUseCase
{
    Task Execute(long id);
}
