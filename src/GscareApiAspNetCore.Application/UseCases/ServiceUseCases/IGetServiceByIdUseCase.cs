using GscareApiAspNetCore.Communication.Responses.ServiceReponses;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public interface IGetServiceByIdUseCase
{
    Task<ResponseServiceJson> Execute(long id);
}
