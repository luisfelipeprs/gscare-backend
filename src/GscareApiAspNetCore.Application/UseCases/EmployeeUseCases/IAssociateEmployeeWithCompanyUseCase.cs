namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IAssociateEmployeeWithCompanyUseCase
{
    Task Execute(long employeeId, long companyId);
}