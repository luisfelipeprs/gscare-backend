using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetAllPatientsUseCase
{
    Task<ResponsePatientsJson> Execute();
}
