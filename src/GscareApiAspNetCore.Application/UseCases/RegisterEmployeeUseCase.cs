using AutoMapper;
using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases;
public class RegisterEmployeeUseCase : IRegisterEmployeeUseCase
{
    private readonly IEmployeeWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterEmployeeUseCase(
        IEmployeeWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredEmployeeJson> Execute(RequestEmployeeJson request)
    {
        Validate(request);
        
        var entity = _mapper.Map<Employee>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredEmployeeJson>(entity);
    }
        
    private void Validate(RequestEmployeeJson request)
    {
        var validator = new EmployeeValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false )
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
