using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Security.Tokens;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using GscareApiAspNetCore.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace GscareApiAspNetCore.Infrastructure.Services.LoggedUser;
public class LoggedUser : ILoggedUser
{
    public readonly ITokenProvider _tokenProvider;

    private readonly IEmployeeReadOnlyRepository _dbContext;

    public LoggedUser(IEmployeeReadOnlyRepository dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<Employee> Employee()
    {
        var token = _tokenProvider.Value();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var indentifier = jwtSecurityToken.Claims.First(c => c.Type == "id_user").Value;

        var userIdentifier = long.Parse(indentifier);

        var employee = await _dbContext.GetById(userIdentifier);

        if (employee == null)
        {
            throw new InvalidOperationException("No employee found with the specified identifier.");
        }

        return employee;
    }
}
