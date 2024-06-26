using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
internal class GetAllPatientsUseCase : IGetAllPatientsUseCase
{
    private readonly IPatientReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetAllPatientsUseCase(IPatientReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponsePatientsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponsePatientsJson
        {
            Patients = _mapper.Map<List<ResponseShortPatientJson>>(result)
        };
    }
}
