using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;

namespace GscareApiAspNetCore.Application.UseCases;
public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllEmployeesUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseEmployeesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseEmployeesJson
        {
            Employees = _mapper.Map<List<ResponseShortEmployeeJson>>(result)
        };
    }
}
