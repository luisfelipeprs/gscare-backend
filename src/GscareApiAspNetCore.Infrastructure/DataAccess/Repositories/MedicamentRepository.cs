using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class MedicamentRepository : IMedicamentReadOnlyRepository, IMedicamentWriteOnlyRepository, IMedicamentUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public MedicamentRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Medicament Medicament)
    {
        await _dbContext.Medicaments.AddAsync(Medicament);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Medicaments.FirstOrDefaultAsync(Medicament => Medicament.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Medicaments.Remove(result);

        return true;
    }

    public async Task<List<Medicament>> GetAll(long patientId)
    {
        return await _dbContext.Medicaments
            .AsNoTracking()
            .Where(m => m.PatientId == patientId)
            .ToListAsync();
        //return await _dbContext.Medicaments.AsNoTracking().ToListAsync();
        //await _dbContext.Medicaments.Where(e => e.UserId == id)
    }

    async Task<Medicament?> IMedicamentReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Medicaments.AsNoTracking().FirstOrDefaultAsync(Medicament => Medicament.Id == id);
    }

    async Task<Medicament?> IMedicamentUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Medicaments.FirstOrDefaultAsync(Medicament => Medicament.Id == id);
    }

    public void Update(Medicament Medicament)
    {
        _dbContext.Medicaments.Update(Medicament);
    }
}
