using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases;
internal class GetUserProfileUseCase : IGetUserProfileUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetUserProfileUseCase(IUserReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
        _repository = repository;
        _mapper = mapper;
    }

    async public Task<ResponseUserProfileJson> Execute()
    {
        var user = await _loggedUser.User();

        return _mapper.Map<ResponseUserProfileJson>(user);
    }
}
