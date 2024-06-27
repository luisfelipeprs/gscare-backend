using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class GetEmployeesByCurrentCompanyUseCase : IGetEmployeesByCurrentCompanyUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetEmployeesByCurrentCompanyUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseEmployeesJson> Execute()
    {
        var loggedInUser = await _loggedUser.User();
        var companyId = loggedInUser.CompanyId;

        if (companyId == null)
        {
            throw new InvalidOperationException("Logged in user is not associated with any company.");
        }

        var result = await _repository.GetEmployeesByCompanyId(companyId.Value);

        return new ResponseEmployeesJson
        {
            Employees = _mapper.Map<List<ResponseShortEmployeeJson>>(result)
        };
    }
}
