using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IGetAllCompaniesUseCase
{
    Task<ResponseCompaniesJson> Execute();
}
