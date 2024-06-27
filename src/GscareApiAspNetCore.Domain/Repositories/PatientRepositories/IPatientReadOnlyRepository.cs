using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
public interface IPatientReadOnlyRepository
{
    Task<List<Patient>> GetPatientsByCompanyId(long companyId);
    Task<List<Patient>> GetAll();
    Task<Patient?> GetById(long id);
    Task<Company?> GetCurrentCompanyByPatient(long currentCompanyId);
}
