using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases;
internal class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public LoginUserUseCase(IUserReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser, IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseTokenJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetByEmail(request.Email);
        if(user == null || user.Password != request.Password)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var token = _accessTokenGenerator.Generate(user.Id);

        return new ResponseTokenJson { AccessToken = token };


        //return _mapper.Map<ResponseRegisteredUserJson>(entity);
        //return new ResponseRegisteredUserJson
        //{
        //    Name = entity.Name,
        //    Tokens = new ResponseTokenJson
        //    {
        //        AccessToken = _accessTokenGenerator.Generate(entity.Id)
        //    }
        //};
    }

    //public async Task<ResponseUserJson> Execute(RequestLoginJson request)
    //{
    //    var user = await _loggedUser.User();

    //    //return new ResponseUserJson(_mapper.Map<ResponseUserJson>(user));
    //}
}
