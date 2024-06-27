using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class UpdatePatientUseCase : IUpdatePatientUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientUpdateOnlyRepository _repository;

    public UpdatePatientUseCase(IMapper mapper, IUnitOfWork unitOfWork, IPatientUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestPatientJson request)
    {
        Validate(request);

        var Patient = await _repository.GetById(Id);

        if (Patient is null)
        {
            throw new NotFoundException("Patient not found.");
        }

        // pega os dados da request e insere dentro do objeto => Patient(ja criado)
        _mapper.Map(request, Patient);

        _repository.Update(Patient);

        await _unitOfWork.Commit();
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
