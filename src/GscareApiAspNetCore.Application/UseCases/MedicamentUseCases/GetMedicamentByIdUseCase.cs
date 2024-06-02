using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public class GetMedicamentByIdUseCase : IGetMedicamentByIdUseCase
{
    private readonly IMedicamentReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetMedicamentByIdUseCase(IMedicamentReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseMedicamentJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseMedicamentJson>(result);
    }
}
