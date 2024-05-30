using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases;
public class GetPatientByIdUseCase : IGetPatientByIdUseCase
{
    private readonly IPatientReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetPatientByIdUseCase(IPatientReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponsePatientJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException("Patient not found.");
        }

        return _mapper.Map<ResponsePatientJson>(result);
    }
}
