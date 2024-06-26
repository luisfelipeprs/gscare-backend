using AutoMapper;
using GscareApiAspNetCore.Domain.Repositories;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
internal class AssociatePatientWithCompanyUseCase : IAssociatePatientWithCompanyUseCase
{
    private readonly IPatientUpdateOnlyRepository _repository;

    public AssociatePatientWithCompanyUseCase(IPatientUpdateOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(long patientId, long companyId)
    {
        // Utilize o método implementado no repositório para associar o patient com a company
        await _repository.AssociatePatientWithCompany(patientId, companyId);
    }
}
