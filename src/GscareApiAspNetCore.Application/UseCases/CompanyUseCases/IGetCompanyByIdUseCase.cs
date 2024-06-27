using GscareApiAspNetCore.Communication.Responses.CompanyResponses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IGetCompanyByIdUseCase
{
    Task<ResponseCompanyJson> Execute(long id);
}
