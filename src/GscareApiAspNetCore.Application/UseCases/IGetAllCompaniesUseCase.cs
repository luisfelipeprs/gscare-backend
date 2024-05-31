using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetAllCompaniesUseCase
{
    Task<ResponseCompaniesJson> Execute();
}
