using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetEmployeeByIdUseCase
{
    Task<ResponseEmployeeJson> Execute(long id);
}
