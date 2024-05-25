using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    public RegisterUserUseCase(
        IUserWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accessTokenGenerator = accessTokenGenerator;
    }

    async public Task<ResponseRegisteredUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = _mapper.Map<User>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        //return _mapper.Map<ResponseRegisteredUserJson>(entity);
        return new ResponseRegisteredUserJson
        {
            Name = entity.Name,
            Tokens = new ResponseTokenJson
            {
                AccessToken = _accessTokenGenerator.Generate(entity.Id)
            }
        };
    }


    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
