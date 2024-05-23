namespace GscareApiAspNetCore.Domain.Security.Tokens;
public interface IAccessTokenValidator
{
    public long ValidateAndGetUserIdentifier(string token);
}
