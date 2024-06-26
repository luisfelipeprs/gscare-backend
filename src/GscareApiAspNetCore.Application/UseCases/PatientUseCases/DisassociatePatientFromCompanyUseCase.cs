using GscareApiAspNetCore.Application.UseCases.PatientUseCases;
using GscareApiAspNetCore.Domain.Repositories;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class DisassociatePatientFromCompanyUseCase : IDisassociatePatientFromCompanyUseCase
{
    private readonly IPatientUpdateOnlyRepository _repository;

    public DisassociatePatientFromCompanyUseCase(IPatientUpdateOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(long patientId)
    {
        // Utilize o método implementado no repositório para desassociar o patient da company
        await _repository.DisassociatePatientFromCompany(patientId);
    }
}   