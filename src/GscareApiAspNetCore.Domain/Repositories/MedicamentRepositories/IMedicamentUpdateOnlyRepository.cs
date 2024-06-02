using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
public interface IMedicamentUpdateOnlyRepository
{
    Task<Medicament?> GetById(long id);
    void Update(Medicament medicament);
}
