using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.CompanyRepositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public class RegisterCompanyUseCase : IRegisterCompanyUseCase
{
    private readonly ICompanyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    public RegisterCompanyUseCase(
        ICompanyWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseRegisteredCompanyJson> Execute(RequestCompanyJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Company>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        //return _mapper.Map<ResponseRegisteredCompanyJson>(entity);
        return _mapper.Map<ResponseRegisteredCompanyJson>(entity);

    }

    private void Validate(RequestCompanyJson request)
    {
        var validator = new CompanyValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
