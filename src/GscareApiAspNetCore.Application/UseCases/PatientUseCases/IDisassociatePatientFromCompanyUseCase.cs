namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IDisassociatePatientFromCompanyUseCase
{
    Task Execute(long patientId);
}
