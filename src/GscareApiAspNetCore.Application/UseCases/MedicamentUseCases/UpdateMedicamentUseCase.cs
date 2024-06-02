using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.MedicamentRepositories;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
public class UpdateMedicamentUseCase : IUpdateMedicamentUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMedicamentUpdateOnlyRepository _repository;

    public UpdateMedicamentUseCase(IMapper mapper, IUnitOfWork unitOfWork, IMedicamentUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestMedicamentJson request)
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
