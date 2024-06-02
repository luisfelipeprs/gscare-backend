using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public interface IGetMedicamentByIdUseCase
{
    Task<ResponseMedicamentJson> Execute(long id);
}
