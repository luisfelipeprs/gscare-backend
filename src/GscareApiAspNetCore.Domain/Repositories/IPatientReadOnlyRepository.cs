using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IPatientReadOnlyRepository
{
    Task<List<Patient>> GetAll();
    Task<Patient?> GetById(long id);
}
