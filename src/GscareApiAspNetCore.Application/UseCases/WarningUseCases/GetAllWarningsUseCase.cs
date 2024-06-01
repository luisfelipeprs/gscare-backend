using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public class GetAllWarningsUseCase : IGetAllWarningsUseCase
{
    private readonly IWarningReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllWarningsUseCase(IWarningReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseWarningsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseWarningsJson
        {
            Companies = _mapper.Map<List<ResponseShortWarningJson>>(result)
        };
        //var result = await _repository.GetAll();

        //return new ResponseCompaniesJson
        //{
        //    Companies = _mapper.Map<List<ResponseShortCompanyJson>>(result)
        //};
    }
}
