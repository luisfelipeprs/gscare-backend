using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
public interface IGetUserProfileUseCase
{
    public Task<ResponseUserProfileJson> Execute();
}
