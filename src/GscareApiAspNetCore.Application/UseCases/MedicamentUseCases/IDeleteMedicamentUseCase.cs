namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public interface IDeleteMedicamentUseCase
{
    Task Execute(long id);
}
