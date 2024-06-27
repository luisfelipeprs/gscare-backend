using GscareApiAspNetCore.Communication.Responses.UserResponses;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
public interface IGetUserProfileUseCase
{
    public Task<ResponseUserProfileJson> Execute();
}
