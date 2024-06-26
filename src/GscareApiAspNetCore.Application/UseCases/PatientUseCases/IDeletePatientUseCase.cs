namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IDeletePatientUseCase
{
    Task Execute(long id);
}
