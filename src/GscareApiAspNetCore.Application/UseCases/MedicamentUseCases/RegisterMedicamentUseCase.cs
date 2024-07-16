using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public class RegisterMedicamentUseCase : IRegisterMedicamentUseCase
{
    private readonly IMedicamentWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterMedicamentUseCase(
        IMedicamentWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredMedicamentJson> Execute(RequestMedicamentJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Medicament>(request);
        entity.PatientId = request.PatientId;

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        //try
        //{
        //    await _repository.Add(entity);
        //    await _unitOfWork.Commit();
        //}
        //catch (GscareException ex)
        //{
        //    // Log the exception or handle it accordingly
        //    throw new System.Exception("An error occurred while saving the entity changes. See the inner exception for details.", ex);
        //}

        return _mapper.Map<ResponseRegisteredMedicamentJson>(entity);

    }

    private void Validate(RequestMedicamentJson request)
    {
        var validator = new MedicamentValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
