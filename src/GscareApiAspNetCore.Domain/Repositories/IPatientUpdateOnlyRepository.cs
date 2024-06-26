using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IPatientUpdateOnlyRepository
{
    Task<Patient?> GetById(long id);
    void Update(Patient Patient);
    Task AssociatePatientWithCompany(long patientId, long companyId);
    Task DisassociatePatientFromCompany(long patientId);
}
