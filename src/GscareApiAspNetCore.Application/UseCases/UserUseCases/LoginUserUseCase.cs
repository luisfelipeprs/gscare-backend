using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using GscareApiAspNetCore.Domain.Security.Tokens;

namespace GscareApiAspNetCore.Application.UseCases.UserUseCases;
internal class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public LoginUserUseCase(IUserReadOnlyRepository repository, IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseTokenJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetByEmail(request.Email);

        if (user == null || user.Password != request.Password)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var token = _accessTokenGenerator.Generate(user.Id);

        return new ResponseTokenJson { AccessToken = token };
    }
}
