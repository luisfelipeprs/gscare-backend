using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Repositories.WarningRepositories;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public class GetWarningByIdUseCase : IGetWarningByIdUseCase
{
    private readonly IWarningReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetWarningByIdUseCase(IWarningReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseWarningJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseWarningJson>(result);
    }
}
