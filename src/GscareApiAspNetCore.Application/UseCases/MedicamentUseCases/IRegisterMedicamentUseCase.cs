using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public interface IRegisterMedicamentUseCase
{
    Task<ResponseRegisteredMedicamentJson> Execute(RequestMedicamentJson request);
}
