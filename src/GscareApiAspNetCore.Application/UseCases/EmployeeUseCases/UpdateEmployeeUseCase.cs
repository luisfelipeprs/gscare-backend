using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class UpdateEmployeeUseCase : IUpdateEmployeeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeUpdateOnlyRepository _repository;

    public UpdateEmployeeUseCase(IMapper mapper, IUnitOfWork unitOfWork, IEmployeeUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestEmployeeJson request)
    {
        Validate(request);

        var employee = await _repository.GetById(Id);

        if (employee is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        // pega os dados da request e insere dentro do objeto => employee(ja criado)
        _mapper.Map(request, employee);

        _repository.Update(employee);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestEmployeeJson request)
    {
        var validator = new EmployeeValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
