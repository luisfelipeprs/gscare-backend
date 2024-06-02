using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public interface IUpdateSupplyUseCase
{
    Task Execute(long Id, RequestSupplyJson request);
}
