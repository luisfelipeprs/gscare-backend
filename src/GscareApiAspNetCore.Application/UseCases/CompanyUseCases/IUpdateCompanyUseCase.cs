using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IUpdateCompanyUseCase
{
    Task Execute(long Id, RequestCompanyJson request);
}
