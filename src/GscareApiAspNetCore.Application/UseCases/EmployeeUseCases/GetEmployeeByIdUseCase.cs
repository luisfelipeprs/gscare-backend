using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class GetEmployeeByIdUseCase : IGetEmployeeByIdUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetEmployeeByIdUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseEmployeeJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseEmployeeJson>(result);
    }
}
