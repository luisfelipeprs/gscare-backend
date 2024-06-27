using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class AssociateEmployeeWithCompanyUseCase : IAssociateEmployeeWithCompanyUseCase
{
    private readonly IEmployeeUpdateOnlyRepository _repository;

    public AssociateEmployeeWithCompanyUseCase(IEmployeeUpdateOnlyRepository repository)
    {
        _repository = repository;
    }
    public async Task Execute(long employeeId, long companyId)
    {
        // Utilize o método implementado no repositório para associar o employee com a company
        await _repository.AssociateEmployeeWithCompany(employeeId, companyId);
    }
}
