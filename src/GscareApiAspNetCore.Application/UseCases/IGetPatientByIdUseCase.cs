using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetPatientByIdUseCase
{
    Task<ResponsePatientJson> Execute(long id);
}
