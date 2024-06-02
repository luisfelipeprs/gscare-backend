using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
public interface IMedicamentReadOnlyRepository
{
    Task<List<Medicament>> GetAll();
    Task<Medicament?> GetById(long id);
}
