using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public interface IUpdateMedicamentUseCase
{
    Task Execute(long Id, RequestMedicamentJson request);
}
