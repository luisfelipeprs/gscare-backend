using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.ServiceReponses;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public class GetServiceByIdUseCase : IGetServiceByIdUseCase
{
    private readonly IServiceReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetServiceByIdUseCase(IServiceReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseServiceJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseServiceJson>(result);
    }
}
