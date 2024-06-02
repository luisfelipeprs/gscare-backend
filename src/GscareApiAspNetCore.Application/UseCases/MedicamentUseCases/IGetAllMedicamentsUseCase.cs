using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public interface IGetAllMedicamentsUseCase
{
    Task<ResponseMedicamentsJson> Execute();
}
