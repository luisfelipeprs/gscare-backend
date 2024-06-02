using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.ServiceRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
public class UpdateServiceUseCase : IUpdateServiceUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceUpdateOnlyRepository _repository;

    public UpdateServiceUseCase(IMapper mapper, IUnitOfWork unitOfWork, IServiceUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestServiceJson request)
    {
        Validate(request);

        var service = await _repository.GetById(Id);

        if (service is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        _mapper.Map(request, service);

        _repository.Update(service);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestServiceJson request)
    {
        var validator = new ServiceValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
