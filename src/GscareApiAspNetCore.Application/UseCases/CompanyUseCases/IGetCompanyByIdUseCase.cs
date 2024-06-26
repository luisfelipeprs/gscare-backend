using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IGetCompanyByIdUseCase
{
    Task<ResponseCompanyJson> Execute(long id);
}
