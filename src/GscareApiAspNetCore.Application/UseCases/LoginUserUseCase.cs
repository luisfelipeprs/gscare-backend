using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases;
internal class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public LoginUserUseCase(IUserReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public Task<ResponseUserJson> Execute(RequestLoginJson request)
    {
        throw new NotImplementedException();
    }

    //public async Task<ResponseUserJson> Execute(RequestLoginJson request)
    //{
    //    var user = await _loggedUser.User();

    //    //return new ResponseUserJson(_mapper.Map<ResponseUserJson>(user));
    //}
}
