using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.PatientResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class GetPatientsByCurrentCompanyUseCase : IGetPatientsByCurrentCompanyUseCase
{
    private readonly IPatientReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetPatientsByCurrentCompanyUseCase(IPatientReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponsePatientsJson> Execute()
    {
        var loggedInUser = await _loggedUser.User();
        var companyId = loggedInUser.CompanyId;

        if (companyId == null)
        {
            throw new InvalidOperationException("Logged in user is not associated with any company.");
        }

        var result = await _repository.GetPatientsByCompanyId(companyId.Value);

        return new ResponsePatientsJson
        {
            Patients = _mapper.Map<List<ResponseShortPatientJson>>(result)
        };
    }
}
