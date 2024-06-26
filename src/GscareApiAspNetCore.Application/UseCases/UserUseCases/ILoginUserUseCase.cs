using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
public interface ILoginUserUseCase
{
    Task<ResponseTokenJson> Execute(RequestLoginJson request);
}
