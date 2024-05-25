using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetUserProfileUseCase
{
    public Task<ResponseUserProfileJson> Execute();
}
