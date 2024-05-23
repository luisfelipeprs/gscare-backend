using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases;
public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetAllEmployeesUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseEmployeesJson> Execute()
    {
        var user = await _loggedUser.Employee();

        var result = await _repository.GetAll();

        return new ResponseEmployeesJson
        {
            Employees = _mapper.Map<List<ResponseShortEmployeeJson>>(result)
        };
    }
}
