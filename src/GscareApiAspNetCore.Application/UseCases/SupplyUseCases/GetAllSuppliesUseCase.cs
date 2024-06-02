using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public class GetAllSuppliesUseCase : IGetAllSuppliesUseCase
{
    private readonly ISupplyReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllSuppliesUseCase(ISupplyReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseSuppliesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseSuppliesJson
        {
            Supply = _mapper.Map<List<ResponseShortSupplyJson>>(result)
        };
    }
}
