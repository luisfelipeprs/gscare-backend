using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Enums;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public UsersRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdWithRelations(long id)
    {
        return await _dbContext.Users
            .Include(u => u.Employee)
            .Include(u => u.Patient)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    async Task<User?> IUserReadOnlyRepository.GetById(long id)
    {
        var user = await _dbContext.Users
            .Include(u => u.Employee)
            .Include(u => u.Patient)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return null;

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                user.Employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
                break;
            case RolesUserType.Patient:
                user.Patient = await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == user.PatientId);
                break;
            case RolesUserType.Company:
                user.Company = await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == user.CompanyId);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }

        return user;
    }


    async Task<User?> IUserUpdateOnlyRepository.GetById(long id)
    {
        var user = await _dbContext.Users
            .Include(u => u.Employee)
            .Include(u => u.Patient)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return null;

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                user.Employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
                break;
            case RolesUserType.Patient:
                user.Patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == user.PatientId);
                break;
            case RolesUserType.Company:
                user.Company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == user.CompanyId);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }

        return user;
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await _dbContext.Users
            .Include(u => u.Employee)
            .Include(u => u.Patient)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
            return null;

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                user.Employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
                break;
            case RolesUserType.Patient:
                user.Patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == user.PatientId);
                break;
            case RolesUserType.Company:
                user.Company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == user.CompanyId);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }

        return user;
    }

    public async Task Add(User user)
    {
        switch (user.UserType)
        {
            case RolesUserType.Employee:
                // Adicione o Employee diretamente, não o User
                await _dbContext.Employees.AddAsync(user.Employee!);
                break;
            case RolesUserType.Patient:
                // Adicione o Patient diretamente, não o User
                await _dbContext.Patients.AddAsync(user.Patient!);
                break;
            case RolesUserType.Company:
                // Adicione a Company diretamente, não o User
                await _dbContext.Companies.AddAsync(user.Company!);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }

        // Adicione o User ao contexto, independentemente do tipo
        await _dbContext.Users.AddAsync(user);
    }


    public void Update(User user)
    {
        switch (user.UserType)
        {
            case RolesUserType.Employee:
                _dbContext.Employees.Update(user.Employee!);
                break;
            case RolesUserType.Patient:
                _dbContext.Patients.Update(user.Patient!);
                break;
            case RolesUserType.Company:
                _dbContext.Companies.Update(user.Company!);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }
        _dbContext.Users.Update(user);
    }

    public async Task<bool> Delete(long id)
    {
        var user = await _dbContext.Users
            .Include(u => u.Employee)
            .Include(u => u.Patient)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return false;

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                user.Employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);
                break;
            case RolesUserType.Patient:
                user.Patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == user.PatientId);
                break;
            case RolesUserType.Company:
                user.Company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == user.CompanyId);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }

        switch (user.UserType)
        {
            case RolesUserType.Employee:
                _dbContext.Employees.Remove(user.Employee!);
                break;
            case RolesUserType.Patient:
                _dbContext.Patients.Remove(user.Patient!);
                break;
            case RolesUserType.Company:
                _dbContext.Companies.Remove(user.Company!);
                break;
            default:
                throw new InvalidOperationException("Invalid user type.");
        }
        _dbContext.Users.Remove(user);
        return true;
    }
}
