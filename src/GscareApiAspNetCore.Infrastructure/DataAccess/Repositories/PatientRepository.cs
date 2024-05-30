using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class PatientRepository : IPatientReadOnlyRepository, IPatientUpdateOnlyRepository, IPatientWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public PatientRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Patient Patient)
    {
        await _dbContext.Patients.AddAsync(Patient);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Patients.FirstOrDefaultAsync(Patient => Patient.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Patients.Remove(result);

        return true;
    }

    public async Task<List<Patient>> GetAll()
    {
        return await _dbContext.Patients.AsNoTracking().ToListAsync();
        //await _dbContext.Patients.Where(e => e.UserId == id)
    }

    async Task<Patient?> IPatientReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(Patient => Patient.Id == id);
    }

    async Task<Patient?> IPatientUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Patients.FirstOrDefaultAsync(Patient => Patient.Id == id);
    }

    public void Update(Patient Patient)
    {
        _dbContext.Patients.Update(Patient);
    }
}
