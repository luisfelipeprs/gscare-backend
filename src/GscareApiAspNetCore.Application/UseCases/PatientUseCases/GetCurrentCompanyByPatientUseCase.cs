using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class GetCurrentCompanyByPatientUseCase : IGetCurrentCompanyByPatientUseCase
{
    private readonly IPatientReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetCurrentCompanyByPatientUseCase(IPatientReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseCompanyJson> Execute()
    {
        var loggedInUser = await _loggedUser.User();

        if (loggedInUser.Patient!.CurrentCompanyId == null)
        {
            throw new NotFoundException("No current company found");
        }

        var currentCompanyId = (long)loggedInUser.Patient.CurrentCompanyId;

        var result = await _repository.GetCurrentCompanyByPatient(currentCompanyId);

        if (result is null)
        {
            throw new NotFoundException("No current company found");
        }

        return _mapper.Map<ResponseCompanyJson>(result);
    }
}
