using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    //private readonly ILoggedUser _loggedUser;
    public GetAllEmployeesUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        //_loggedUser = loggedUser;
    }

    public async Task<ResponseEmployeesJson> Execute()
    {
        //var user = await _loggedUser.Employee();

        var result = await _repository.GetAll();

        return new ResponseEmployeesJson
        {
            Employees = _mapper.Map<List<ResponseShortEmployeeJson>>(result)
        };
    }
}
