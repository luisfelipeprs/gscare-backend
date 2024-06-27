using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;
using GscareApiAspNetCore.Domain.Repositories.CompanyRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public class GetAllCompaniesUseCase : IGetAllCompaniesUseCase
{
    private readonly ICompanyReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllCompaniesUseCase(ICompanyReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseCompaniesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseCompaniesJson
        {
            Companies = _mapper.Map<List<ResponseShortCompanyJson>>(result)
        };
        //var result = await _repository.GetAll();

        //return new ResponseCompaniesJson
        //{
        //    Companies = _mapper.Map<List<ResponseShortCompanyJson>>(result)
        //};
    }
}
