using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestUserJson request);
}
