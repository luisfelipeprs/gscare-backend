using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface ILoginUserUseCase
{
    Task<ResponseUserJson> Execute(RequestLoginJson request);
}
