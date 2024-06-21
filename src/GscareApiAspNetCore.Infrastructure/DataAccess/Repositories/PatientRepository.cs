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
    async Task<Patient?> IPatientUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }


    async Task<Patient?> IPatientReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Patient>> GetAll()
    {
        return await _dbContext.Patients.AsNoTracking().ToListAsync();
    }

    public async Task Add(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
    }

    public void Update(Patient patient)
    {
        _dbContext.Patients.Update(patient);
    }

    public async Task<bool> Delete(long id)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        if (patient == null)
            return false;

        _dbContext.Patients.Remove(patient);
        return true;
    }

    //=============================



}
