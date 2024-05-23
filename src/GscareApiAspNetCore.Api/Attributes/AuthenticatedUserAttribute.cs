using GscareApiAspNetCore.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Attributes;

public class AuthenticatedUserAttribute : TypeFilterAttribute
{
    public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
    {
    }
}
