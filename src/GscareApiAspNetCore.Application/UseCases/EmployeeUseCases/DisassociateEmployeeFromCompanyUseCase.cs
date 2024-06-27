using AutoMapper;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class DisassociateEmployeeFromCompanyUseCase : IDisassociateEmployeeFromCompanyUseCase
{
    private readonly IEmployeeUpdateOnlyRepository _repository;

    public DisassociateEmployeeFromCompanyUseCase(IEmployeeUpdateOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(long employeeId)
    {
        // Utilize o método implementado no repositório para desassociar o employee da company
        await _repository.DisassociateEmployeeFromCompany(employeeId);
    }
}