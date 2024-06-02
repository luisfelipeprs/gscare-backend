using GscareApiAspNetCore.Communication.Responses.ServiceReponses;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public interface IGetAllServicesUseCase
{
    Task<ResponseServicesJson> Execute();
}
