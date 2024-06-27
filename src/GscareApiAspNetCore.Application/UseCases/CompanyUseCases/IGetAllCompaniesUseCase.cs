using GscareApiAspNetCore.Communication.Responses.CompanyResponses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IGetAllCompaniesUseCase
{
    Task<ResponseCompaniesJson> Execute();
}
