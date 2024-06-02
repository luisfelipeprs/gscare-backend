using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.ServiceReponses;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public class GetAllServicesUseCase : IGetAllServicesUseCase
{
    private readonly IServiceReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllServicesUseCase(IServiceReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseServicesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseServicesJson
        {
            Service = _mapper.Map<List<ResponseShortServiceJson>>(result)
        };
    }
}
