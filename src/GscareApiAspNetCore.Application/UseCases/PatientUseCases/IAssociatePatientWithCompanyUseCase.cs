namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;

public interface IAssociatePatientWithCompanyUseCase
{
    Task Execute(long patientId, long companyId);
}