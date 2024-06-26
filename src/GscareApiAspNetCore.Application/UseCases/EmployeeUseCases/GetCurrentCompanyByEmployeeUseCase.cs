using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class GetCurrentCompanyByEmployeeUseCase : IGetCurrentCompanyByEmployeeUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetCurrentCompanyByEmployeeUseCase(IEmployeeReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseCompanyJson> Execute()
    {
        var loggedInUser = await _loggedUser.User();

        if (loggedInUser.Employee!.CurrentCompanyId == null)
        {
            throw new NotFoundException("No current company found");
        }

        var currentCompanyId = (long)loggedInUser.Employee.CurrentCompanyId;

        var result = await _repository.GetCurrentCompanyByEmployee(currentCompanyId);

        if (result is null)
        {
            throw new NotFoundException("No current company found");
        }

        return _mapper.Map<ResponseCompanyJson>(result);
    }
}
