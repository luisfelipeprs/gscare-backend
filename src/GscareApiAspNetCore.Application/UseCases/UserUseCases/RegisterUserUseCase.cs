using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Communication.Responses.UserResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
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

        var user = _mapper.Map<User>(request);

        //switch (user.UserType)
        //{
        //    case RolesUserType.Employee:
        //        await _repository.AddEmployee(user.Employee!);
        //        break;
        //    case RolesUserType.Patient:
        //        await _repository.AddPatient(user.Patient!);
        //        break;
        //    case RolesUserType.Company:
        //        await _repository.AddCompany(user.Company!);
        //        break;
        //    default:
        //        throw new InvalidOperationException("Invalid user type.");
        //}

        await _repository.Add(user);

        await _unitOfWork.Commit();

        //return _mapper.Map<ResponseRegisteredUserJson>(user);
        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Tokens = new ResponseTokenJson
            {
                AccessToken = _accessTokenGenerator.Generate(user.Id)
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
