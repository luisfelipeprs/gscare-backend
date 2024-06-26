using AutoMapper;
using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
public class RegisterEmployeeUseCase : IRegisterEmployeeUseCase
{
    private readonly IEmployeeWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    public RegisterEmployeeUseCase(
        IEmployeeWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseRegisteredEmployeeJson> Execute(RequestEmployeeJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Employee>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        //return _mapper.Map<ResponseRegisteredEmployeeJson>(entity);
        return new ResponseRegisteredEmployeeJson
        {
            NomeCompleto = entity.NomeCompleto,
            Tokens = new ResponseTokenJson
            {
                AccessToken = _accessTokenGenerator.Generate(entity.Id)
            }
        };
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
