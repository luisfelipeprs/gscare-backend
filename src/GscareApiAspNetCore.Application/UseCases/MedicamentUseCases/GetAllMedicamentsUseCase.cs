using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public class GetAllMedicamentsUseCase : IGetAllMedicamentsUseCase
{
    private readonly IMedicamentReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllMedicamentsUseCase(IMedicamentReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseMedicamentsJson> Execute(long patientId)
    {
        var result = await _repository.GetAll(patientId);

        return new ResponseMedicamentsJson
        {
            Medicament = _mapper.Map<List<ResponseShortMedicamentJson>>(result)
        };
    }
}
