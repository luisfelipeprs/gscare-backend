using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.SupplyRepositories;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
public class UpdateSupplyUseCase : IUpdateSupplyUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplyUpdateOnlyRepository _repository;

    public UpdateSupplyUseCase(IMapper mapper, IUnitOfWork unitOfWork, ISupplyUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestSupplyJson request)
    {
        Validate(request);

        var supply = await _repository.GetById(Id);

        if (supply is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        _mapper.Map(request, supply);

        _repository.Update(supply);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestSupplyJson request)
    {
        var validator = new SupplyValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
