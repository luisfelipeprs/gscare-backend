using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetCompanyByIdUseCase
{
    Task<ResponseCompanyJson> Execute(long id);
}
