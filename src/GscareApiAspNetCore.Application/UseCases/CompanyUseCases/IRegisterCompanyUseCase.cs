using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IRegisterCompanyUseCase
{
    Task<ResponseRegisteredCompanyJson> Execute(RequestCompanyJson request);
}
