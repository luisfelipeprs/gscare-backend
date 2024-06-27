using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class PatientRepository : IPatientReadOnlyRepository, IPatientUpdateOnlyRepository, IPatientWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public PatientRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // No repositório UsersRepository
    public async Task AssociatePatientWithCompany(long patientId, long companyId)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
        if (patient == null)
        {
            throw new ArgumentException("Patient not found", nameof(patientId));
        }

        var company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new ArgumentException("Company not found", nameof(companyId));
        }

        patient.CurrentCompanyId = companyId;
        patient.CurrentCompany = company;

        await _dbContext.SaveChangesAsync();
    }

    // No repositório UsersRepository
    public async Task DisassociatePatientFromCompany(long patientId)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
        if (patient == null)
        {
            throw new ArgumentException("Patient not found", nameof(patientId));
        }

        patient.CurrentCompanyId = null;
        patient.CurrentCompany = null;

        await _dbContext.SaveChangesAsync();
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

    public async Task<List<Patient>> GetPatientsByCompanyId(long companyId)
    {
        return await _dbContext.Patients
            .Where(p => p.CurrentCompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Company?> GetCurrentCompanyByPatient(long currentCompanyId)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == currentCompanyId);
    }
}
