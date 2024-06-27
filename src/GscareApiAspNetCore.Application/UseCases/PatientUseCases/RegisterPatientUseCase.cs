using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.PatientResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class RegisterPatientUseCase : IRegisterPatientUseCase
{
    private readonly IPatientWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterPatientUseCase(IMapper mapper, IUnitOfWork unitOfWork, IPatientWriteOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<ResponseRegisteredPatientJson> Execute(RequestPatientJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Patient>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        //return _mapper.Map<ResponseRegisteredEmployeeJson>(entity);
        return _mapper.Map<ResponseRegisteredPatientJson>(entity);
    }

    private void Validate(RequestPatientJson request)
    {
        var validator = new PatientValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
