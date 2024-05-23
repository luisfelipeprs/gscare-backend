using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace GscareApiAspNetCore.Api.Filters;

public class AuthenticatedUserFilter : IAsyncAuthorizationFilter
{
    private readonly IAccessTokenValidator _accessTokenValidator;
    private readonly IEmployeeReadOnlyRepository _repository;

    public AuthenticatedUserFilter(
        IAccessTokenValidator accessTokenValidator,
        IEmployeeReadOnlyRepository repository)
    {
        _accessTokenValidator = accessTokenValidator;
        _repository = repository;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context);

            var userIdentifier = _accessTokenValidator.ValidateAndGetUserIdentifier(token);

            var exist = await _repository.GetById(userIdentifier);
            if (exist == null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_WITHOUT_PERMISSION_ACCESS_RESOURCE);
            }
        }
        catch (SecurityTokenExpiredException)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenIsExpired")
            {
                TokenIsExpired = true,
            });
        }
        catch (NotFoundException ex)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceErrorMessages.USER_WITHOUT_PERMISSION_ACCESS_RESOURCE));
        }
    }

    private static string TokenOnRequest(AuthorizationFilterContext context)
    {
        var authentication = context.HttpContext.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication))
        {
            throw new NotFoundException(ResourceErrorMessages.NO_TOKEN);
        }

        // "Bearer abcd1234"
        return authentication["Bearer ".Length..].Trim();
    }
}
