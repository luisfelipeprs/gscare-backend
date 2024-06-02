using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public class GetSupplyByIdUseCase : IGetSupplyByIdUseCase
{
    private readonly ISupplyReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetSupplyByIdUseCase(ISupplyReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseSupplyJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseSupplyJson>(result);
    }
}
