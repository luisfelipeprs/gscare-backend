namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public interface IDisassociateEmployeeFromCompanyUseCase
{
    Task Execute(long employeeId);
}
