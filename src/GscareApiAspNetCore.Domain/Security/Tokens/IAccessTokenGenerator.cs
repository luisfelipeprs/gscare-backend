namespace GscareApiAspNetCore.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    public string Generate(long userIdentifier);
}
