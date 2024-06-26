using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public interface IRegisterCompanyUseCase
{
    Task<ResponseRegisteredCompanyJson> Execute(RequestCompanyJson request);
}
