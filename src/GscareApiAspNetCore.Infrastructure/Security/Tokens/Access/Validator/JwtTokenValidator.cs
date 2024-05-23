using GscareApiAspNetCore.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GscareApiAspNetCore.Infrastructure.Security.Tokens.Access.Validator;
public class JwtTokenValidator : JwtTokenHandler, IAccessTokenValidator
{
    private readonly string _signingKey;

    public JwtTokenValidator(string signingKey) => _signingKey = signingKey;

    public long ValidateAndGetUserIdentifier(string token)
    {
        var validationParameter = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey)),
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameter, out SecurityToken validatedToken);

            var userIdentifier = principal.Claims.First(c => c.Type == "id_user").Value;

            return long.Parse(userIdentifier);
        }
        catch (SecurityTokenException ex)
        {
            Console.WriteLine($"Token validation failed: {ex.Message}");
            throw;
        }
    }
}

