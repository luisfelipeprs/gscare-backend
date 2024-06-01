using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public interface IGetAllWarningsUseCase
{
    Task<ResponseWarningsJson> Execute();
}
