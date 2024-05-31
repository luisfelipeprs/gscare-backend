using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IUpdateCompanyUseCase
{
    Task Execute(long Id, RequestCompanyJson request);
}
