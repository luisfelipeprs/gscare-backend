using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases.WarningUseCases;
public class UpdateWarningUseCase : IUpdateWarningUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarningUpdateOnlyRepository _repository;

    public UpdateWarningUseCase(IMapper mapper, IUnitOfWork unitOfWork, IWarningUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestWarningJson request)
    {
        Validate(request);

        var warning = await _repository.GetById(Id);

        if (warning is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        _mapper.Map(request, warning);

        _repository.Update(warning);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestWarningJson request)
    {
        var validator = new WarningValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
